using ACMESharp.HTTP;
using ACMESharp.PKI;
using ACMESharp.POSH.Util;
using ACMESharp.Util;
using ACMESharp.Vault;
using ACMESharp.Vault.Model;
using ACMESharp.Vault.Util;
using System;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace ACMESharp.POSH
{
	/// <summary>
	/// <para type="synopsis">
	/// </para>
	/// <para type="description">
	/// </para>
	/// </summary>
	[Cmdlet(VerbsCommon.Remove, "Certificate", DefaultParameterSetName = PSET_DEFAULT)]
    [OutputType(typeof(CertificateInfo))]
    public class DeleteCertificate : AcmeCmdlet
	{
        public const string PSET_DEFAULT = "Default";
        public const string PSET_LOCAL_ONLY = "LocalOnly";

        /// <summary>
        /// <para type="description">
        ///     A reference (ID or alias) to a previously defined Certificate request.
        /// </para>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0)]
        [Alias("Ref")]
        public string CertificateRef
        { get; set; }

        ///// <summary>
        ///// <para type="description">
        /////   Indicates that updates should be performed locally only, and no attempt
        /////   should be made to retrieve the current status from the ACME CA Server.
        ///// </para>
        ///// </summary>
        //[Parameter(ParameterSetName = PSET_LOCAL_ONLY)]
        //public SwitchParameter LocalOnly
        //{ get; set; }

        /// <summary>
        /// <para type="description">
        ///     Specifies a Vault profile name that will resolve to the Vault instance to be
        ///     used for all related operations and storage/retrieval of all related assets.
        /// </para>
        /// </summary>
        [Parameter]
        public string VaultProfile
        { get; set; }

        protected override void ProcessRecord()
        {
            using (var vlt = Util.VaultHelper.GetVault(VaultProfile))
            {
                vlt.OpenStorage();
                var v = vlt.LoadVault();

                if (v.Registrations == null || v.Registrations.Count < 1)
                    throw new InvalidOperationException("No registrations found");

                var ri = v.Registrations[0];
                var r = ri.Registration;

                if (v.Certificates == null || v.Certificates.Count < 1)
                    throw new InvalidOperationException("No certificates found");

                var ci = v.Certificates.GetByRef(CertificateRef, throwOnMissing: false);
                if (ci == null)
                    throw new Exception("Unable to find a Certificate for the given reference");

                // PATCH - NEW CODE
                v.Certificates.Remove(ci.Id);


                vlt.SaveVault(v);

                WriteObject(ci);
            }
        }
    }
}

using ACMESharp.POSH.Util;
using ACMESharp.Util;
using System;
using System.Management.Automation;

namespace ACMESharp.POSH
{
	/// <summary>
	/// <para type="synopsis">
	/// </para>
	/// <para type="description">
	/// </para>
	/// </summary>
	[Cmdlet(VerbsCommon.Remove, "Identifier", DefaultParameterSetName = PSET_DEFAULT)]
    public class RemoveIdentifier : AcmeCmdlet
	{
        public const string PSET_DEFAULT = "Default";
        public const string PSET_CHALLENGE = "Challenge";
        public const string PSET_LOCAL_ONLY = "LocalOnly";

        /// <summary>
        /// <para type="description">
        ///     A reference (ID or alias) to a previously defined Identifier submitted
        ///     to the ACME CA Server for verification.
        /// </para>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0)]
        [Alias("Ref")]
        public string IdentifierRef
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

                if (v.Identifiers == null || v.Identifiers.Count < 1)
                    throw new InvalidOperationException("No identifiers found");

                var ii = v.Identifiers.GetByRef(IdentifierRef, throwOnMissing: false);
                if (ii == null)
                    throw new Exception("Unable to find an Identifier for the given reference");

                var authzState = ii.Authorization;

                // PATCH - NEW CODE
                v.Identifiers.Remove(ii.Id);

                vlt.SaveVault(v);

                WriteObject(authzState);
            }
        }
    }
}

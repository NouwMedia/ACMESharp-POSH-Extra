## For a reference of this file's elements, see:
##    https://technet.microsoft.com/library/hh849709.aspx
##    https://technet.microsoft.com/en-us/library/dd878297(v=vs.85).aspx

## 64-bit:
##    %SystemRoot%\system32\WindowsPowerShell\v1.0\powershell.exe
## 32-bit:
##    %SystemRoot%\syswow64\WindowsPowerShell\v1.0\powershell.exe

@{
	RootModule = 'ACMESharp-POSH-Extra.dll'
	ModuleVersion = '0.1'
	# GUID = ''
	
	Author = 'Nouw Media'

	CompanyName = 'Nouw Media'

	Copyright = '(c) 2018 Nouw Media'	

	# Description = ""

	# Default prefix for commands exported from this module. Override the default prefix using Import-Module -Prefix.
	DefaultCommandPrefix = 'ACME'

	## Minimum version of the Windows PowerShell engine required by this module
	## This does not appear to be enforce for versions > 2.0 as per
	##    https://technet.microsoft.com/en-us/library/dd878297(v=vs.85).aspx
	PowerShellVersion = '3.0'

	DotNetFrameworkVersion = '4.5'

	# Private data to pass to the module specified in RootModule/ModuleToProcess. This may also contain a PSData hashtable with additional module metadata used by PowerShell.
	PrivateData = @{

		PSData = @{

			# Tags applied to this module. These help with module discovery in online galleries.
			# Tags = @('pki','ssl','tls','security','certificates','letsencrypt','acme','powershell','acmesharp')

			# A URL to the license for this module.
			LicenseUri = 'https://raw.githubusercontent.com/NouwMedia/ACMESharp-POSH-Extra/master/LICENSE'

			# A URL to the main website for this project.
			ProjectUri = 'https://github.com/NouwMedia/ACMESharp-POSH-Extra'

			# A URL to an icon representing this module.
			# IconUri = 'https://cdn.rawgit.com/NouwMedia/ACMESharp-POSH-Extra/master/artwork/'

			# ReleaseNotes of this module
			# ReleaseNotes = 'Please see the release notes from the release distribution page: https://github.com/NouwMedia/ACMESharp-POSH-Extra/releases'

		} # End of PSData hashtable

	} # End of PrivateData hashtable

	# Modules to import as nested modules of the module specified in RootModule/ModuleToProcess
	# NestedModules = @( "ACMESharp-Extensions\ACMESharp-Extensions.psd1" )

	# Assemblies that must be loaded prior to importing this module
	#RequiredAssemblies = @( 'ACMESharp.dll' )

	# Script files (.ps1) that are run in the caller's environment prior to importing this module.
	#ScriptsToProcess = @( '_ModInit.ps1' )


}
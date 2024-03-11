﻿using Velopack.Packaging;

namespace Velopack.Vpk.Commands;

public class OsxPackCommand : OsxBundleCommand
{
    public string ReleaseNotes { get; private set; }

    public DeltaMode DeltaMode { get; private set; }

    public bool NoPackage { get; private set; }

    public string PackageWelcome { get; private set; }

    public string PackageReadme { get; private set; }

    public string PackageLicense { get; private set; }

    public string PackageConclusion { get; private set; }

    public string SigningAppIdentity { get; private set; }

    public string SigningInstallIdentity { get; private set; }

    public string SigningEntitlements { get; private set; }

    public string NotaryProfile { get; private set; }

    public string NotaryAppleId { get; private set; }

    public string NotaryAppPassword { get; private set; }

    public string NotaryTeamId { get; private set; }

    public bool IncludePdb { get; set; }

    public OsxPackCommand()
        : base("pack", "Converts application files into a release and installer.")
    {
        AddOption<FileInfo>((v) => ReleaseNotes = v.ToFullNameOrNull(), "--releaseNotes")
            .SetDescription("File with markdown-formatted notes for this version.")
            .SetArgumentHelpName("PATH")
            .MustExist();

        AddOption<DeltaMode>((v) => DeltaMode = v, "--delta")
            .SetDefault(DeltaMode.BestSpeed)
            .SetDescription("Set the delta generation mode.");

        AddOption<bool>((v) => NoPackage = v, "--noPkg")
            .SetDescription("Skip generating a .pkg installer.");

        AddOption<FileInfo>((v) => PackageWelcome = v.ToFullNameOrNull(), "--pkgWelcome")
            .SetDescription("Set the installer package welcome content.")
            .SetArgumentHelpName("PATH")
            .MustExist();

        AddOption<FileInfo>((v) => PackageReadme = v.ToFullNameOrNull(), "--pkgReadme")
            .SetDescription("Set the installer package readme content.")
            .SetArgumentHelpName("PATH")
            .MustExist();

        AddOption<FileInfo>((v) => PackageLicense = v.ToFullNameOrNull(), "--pkgLicense")
            .SetDescription("Set the installer package license content.")
            .SetArgumentHelpName("PATH")
            .MustExist();

        AddOption<FileInfo>((v) => PackageConclusion = v.ToFullNameOrNull(), "--pkgConclusion")
            .SetDescription("Set the installer package conclusion content.")
            .SetArgumentHelpName("PATH")
            .MustExist();

        AddOption<string>((v) => SigningAppIdentity = v, "--signAppIdentity")
            .SetDescription("The subject name of the cert to use for app code signing.")
            .SetArgumentHelpName("SUBJECT");

        AddOption<string>((v) => SigningInstallIdentity = v, "--signInstallIdentity")
            .SetDescription("The subject name of the cert to use for installation packages.")
            .SetArgumentHelpName("SUBJECT");

        AddOption<FileInfo>((v) => SigningEntitlements = v.ToFullNameOrNull(), "--signEntitlements")
            .SetDescription("Path to entitlements file for hardened runtime signing.")
            .SetArgumentHelpName("PATH")
            .MustExist()
            .RequiresExtension(".entitlements");

        AddOption<string>((v) => NotaryProfile = v, "--notaryProfile")
            .SetDescription("Name of profile containing Apple credentials stored with notarytool.")
            .SetArgumentHelpName("NAME");

        AddOption<string>((v) => NotaryAppleId = v, "--notaryAppleId")
            .SetDescription("Name of profile containing Apple credentials stored with notarytool.")
            .SetArgumentHelpName("NAME");

        AddOption<string>((v) => NotaryAppPassword = v, "--notaryAppPassword")
            .SetDescription("Name of profile containing Apple credentials stored with notarytool.")
            .SetArgumentHelpName("NAME");

        AddOption<string>((v) => NotaryTeamId = v, "--notaryTeamId")
            .SetDescription("Name of profile containing Apple credentials stored with notarytool.")
            .SetArgumentHelpName("NAME");

        AddOption<bool>((v) => IncludePdb = v, "--includePdb")
            .SetDescription("Include PDB files in the release instead of removing.")
            .SetHidden();
    }
}
var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");


var buildDir = Directory("./src/LowLevelHooking/bin") + Directory(configuration);
var pubDir = Directory("./pub");


Task("Clean")
    .Does(() =>
{
    CleanDirectory(buildDir);
});



Task("Build")
    .IsDependentOn("Clean")
    .Does(() =>
{
    // Kind of terrible, see https://github.com/Microsoft/msbuild/issues/1377    
    var msbuild15path = System.IO.Path.Combine(
        System.IO.Directory.EnumerateDirectories(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Microsoft Visual Studio", "2017")).First(),
        "MSBuild", "15.0", "Bin", "msbuild.exe");
    
    MSBuild("./src/LowLevelHooking.sln", new MSBuildSettings
    {
        Configuration = configuration,
        ToolPath = msbuild15path
    });
});



Task("Pack")
    .IsDependentOn("Build")
    .Does(() =>
{
    var versionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(buildDir + Directory("netstandard1.3") + File("LowLevelHooking.dll"));
    CreateDirectory(pubDir);
    
    NuGetPack(new NuGetPackSettings
    {
        Id = "LowLevelHooking",
        Version = versionInfo.ProductVersion,
        Title = versionInfo.ProductName,
        Authors = new[] { versionInfo.CompanyName},
        Description = versionInfo.FileDescription,
        ProjectUrl = new Uri("https://github.com/jnm2/LowLevelHooking"),
        LicenseUrl = new Uri("https://github.com/jnm2/LowLevelHooking/blob/master/LICENSE.txt"),
        Copyright = versionInfo.LegalCopyright,
        ReleaseNotes = new[] { "https://github.com/jnm2/LowLevelHooking/releases/v" + versionInfo.ProductVersion },
        Tags = new[] { "keyboard", "hook", "key", "hotkey", "windows" },
        Files =
            System.IO.Directory.EnumerateDirectories(buildDir)
            .Select(System.IO.Path.GetFileName)
            .SelectMany(targetDir => new[]
            {
                new NuSpecContent { Source = targetDir + @"\LowLevelHooking.dll", Target = @"lib\" + targetDir },
                new NuSpecContent { Source = targetDir + @"\LowLevelHooking.xml", Target = @"lib\" + targetDir }
            })
            .ToList(),
        BasePath = buildDir,
        OutputDirectory = pubDir
    });
});



Task("Default")
    .IsDependentOn("Build");



RunTarget(target);
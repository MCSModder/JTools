namespace TierneyJohn.MiChangSheng.JTools.Exception.AssetBundleException;

public class AssetBundleFileNotFoundException(string fileName)
    : AssetBundleException($"[{fileName}] The AssetBundle file does not exist.");
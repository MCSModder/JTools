namespace TierneyJohn.MiChangSheng.JTools.Exception.ArchiveException;

/// <summary>
/// ArchiveFile 文件不存在异常
/// </summary>
/// <param name="fileName">异常文件名称</param>
public class ArchiveFileNotExistException(string fileName)
    : ArchiveException($"[{fileName}] The archive file does not exist.");
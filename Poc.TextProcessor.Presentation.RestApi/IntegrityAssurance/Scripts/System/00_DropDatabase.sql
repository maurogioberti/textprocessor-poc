USE master;
IF EXISTS(SELECT * FROM sys.databases WHERE name = 'PocTextProcessor')
BEGIN
    ALTER DATABASE [PocTextProcessor] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [PocTextProcessor];
END;
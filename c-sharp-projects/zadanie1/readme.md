# Before pulling, read me
* `verify` boolean is for optional checksum verification
* `verify` boolean is here only for encryption and compression. It doesn't affect anything if in other type of action. It's set to false if gotten rid of
* Logic is stored in FileOperations class library in c-sharp-projects\FileOperations

## `type` options
- `encrypt`
- `decrypt`
- `compress`
- `decompress`
- `copy`
- `delete`

## Latest changes
- added `copyDestination` variable required for every `copy` task
- added `encryptionPassword` variable required for every `encrypt`/`decrypt` task
- an error with copying directories without subdirectories in them has been found and dealt with
- `ProtectedData` was changed back to `SharpAESCrypt` for multiplatform purposes
- `datetime` support added

## Json example
```
{
  "tasks":
  [
    {
      "task": 
      {
        "title": "Video compression",
        "type": "compress",
        "source": "D:\misc\test.mp4",
        "verify": true,
        "datetime": "12:00 10/06/2021",
      },
    },
    {
      "task": 
      {
        "title": ".jpg encryption",
        "type": "encrypt",
        "source": "D:\misc\pic.jpg",
        "encryptionPassword": "8RlbaUk4",
        "verify": true,
        "datetime": "12:00 10/06/2021",
      },
    },
    {
      "task": 
      {
        "title": ".iso image copying",
        "type": "copy",
        "source": "D:\misc\image.iso",
        "copyDestination": "D:\folderToCopyTo",
        "datetime": "12:00 10/06/2021",
      },
    },
    {
      "task": 
      {
        "title": "deleting files from previous tasks",
        "type": "delete",
        "source": "C:\zadanie1",
        "datetime": "12:00 10/06/2021",
      },
    },
  ]
}
```


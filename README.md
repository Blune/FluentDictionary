# __FluentDictionary__
---

## Purpose
I had a project were I received a dictionary from another API containg keys and their value. Also I had to check if a value for a key was set and if not I had to check for another value to take instead. But this code got very complex soon and it was easy to lose yourselve in there. That's why I started to create this project. Maybe it is also useful for others.

---

## Examples



Returns the first value for a key or the default 'C:\Temp' 

    string fileStorageLocation = FluentDictionary
                                    .For(settingsDictionary)
                                        .Get(Settings.UserFileStorage)
                                        .Or(Settings.GroupFileStorage)
                                        .Or(Settings.SystemFileStorage)
                                        .As<string>("C:\Temp"));

                                        Returns the first value for a key or the default 'C:\Temp' 

Update all the values for certain keys

    FluentDictionary
        .For(settingsDictionary)
            .Set(Settings.UserFileStorage, "C:\MyFolder")
            .And(Settings.GroupFileStorage, "C:\Groups\")
            .And(Settings.SystemFileStorage, "C:\System\Temp"))

Update the first key that is contained

    FluentDictionary
        .For(settingsDictionary)
            .Set(Settings.UserFileStorage, "C:\MyFolder")
            .Or(Settings.GroupFileStorage, "C:\Groups\")
            .Or(Settings.SystemFileStorage, "C:\System\Temp"))"# FluentDictionary" 

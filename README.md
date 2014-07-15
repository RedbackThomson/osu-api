osu-api
=======

A C# implementation of the osu!api

###Example of usage:

```
var api = new osuAPI("Your API Key");
var redback = api.GetUser("Redback", Mode.osu);
Console.WriteLine(redback.count_rank_ss);
```

###Download binaries:

https://github.com/Redback93/osu-api/releases
# rom_db_editor
https://forum.ragezone.com/f884/rom-db-editor-1065772/

I`m developing the Runes Of Magic DataBase Editor. Obviously, it will help you to edit things in data.fdb.

This tool allows you to explore/edit many kind of entities in RoM.

Here you can download it (Requires .NET 4.5):
(v 0.4.6) https://mega.nz/file/mcc1GIbL#p-CqVb...5u4oM5SwzdK1Nw (reupload)
[STRIKE]https://drive.google.com/file/d/0B3WYkjrc1GHab2libk1Eb1NlLWs[/STRIKE]
Old versions:
Spoiler: 


Sources: GITLAB (also you may use issue tracker there)

If you want to save things, make sure you press SAVE button where it exists.
And also, don`t forget to go File->Save All (Ctrl+S in main window) when you want to fix your changes to your hard drive. To make things work, you need to save everything to C:\Runewaker\Client\data, then copy everything from there to C:\Runewaker\Resources\data.

Planned features:

[v0.4.7] Recipes, titles
[v0.5+] Image objects (?)
[v0.6+] Quest support
[???] ? SQL In-game shop editor in admin panel
[???] Patches (save only changed data to apply to different fdb versions)
[unlikely] C# 6.0 Support for scripts
[unlikely] C# IntelliSence for scripts


In case you have found bugs, or if you want to ask for some feature or whatever - feel free to post it here or privately.

PS: Если вы владеете русским, лучше использовать его (в привате).

Big thanks to McBen, Turmalin, and other guys, helped me in that or other way.

==== Usage ===================================
First time usage [optional, but higly recommended to avoid problems]:
Launch the tool
It should show you Setting dialog, if you have no romdb.ini (you should not at the first time)
Set all 3 paths (first one is directory, that should contain data.fdb, the second one will contain *.db files , third should be a path to any of your Global.ini files)
If you want to work with server files (6.0.7): setup path to your server like c:\runewaker\resource\fdb and c:\runewaker\resource\data.
Otherwise, for client: c:\runewaker\client\fdb and c:\runewaker\client\data.
You may select either variant, it`s just for convenience if you got your server running on a different machine from your client`s one.
If you don`t have that data folders - simply create them manualy.

Press save button there.
... (Normal usage)

After all that, you may use tool as you used it before. Now the program will ask you on load and save wether to use default paths or to select different. If you select default way, it will save/load things as they should be without asking you any more questions (except localization loading).

If tool cannot find some file, launch log_romdb.bat (or just 'romdb_editor.exe /v'), load data.fdb and close program. Then send me your log file with your problem description privately, and I will see what I can do.

Note: To make admin panel work - specify Global.ini path in settings!!! Ensure Global.ini has correct SQL value set up

==== About Stats & Treasures =====================
If you want to make an item with one random stat for example, you have to use treasures for that. Just create a treasure with stats you need, or use existing. Then set item`s one of the stats field so, that it`s id == tresure guid and rate == 100% (100000). If you want 1 of n random stats, simply pushing them to stats of an item with rates like 1/n won`t give you desired result. Allso be carefull not to mix up RuneObjects and Stats, while using treasures. I haven`t tested setting rune as a stat, I suppose that nothing neither interesting nor usefull would happen.

Also, to make TreasureObject have more/less slots for items:
1. Set desired count.
2. Re-find this treasure
3. Re-open this treasure.

Note: max count is 100.

=== SCRIPTS About (RoM DB Editor v0.3.2+) ==========
You now can run scripts within editor.
These are for searching or editing things in database and showing any kind of information in HTML (4) format.
Scripts should be written using C# language (.NET v4.0 - 4.5). (C# 6 is not yet supported)
Any of your script would be actualy just a body for a method in a following code:
Code:
using System;
using System.Linq;
using System.Collections.Generic;
using RunesDataBase.TableObjects;
using RunesDataBase.SubScript;
using Runes.Net.Shared;
public class Main
{
    public static void Run(RunesDataBase.SubScript.RunesDataBase db)
    {
    // YOUR CODE HERE
    }
}
Anyway, if you`d like to use scripts, please take a look on script.cs inside the archive first!
To get info about fields/types/methods/... just use Microsoft`s VisualStudio (I`d suggest you to use VS2013 or newer + ReSharper)
Create a C# DLL project, add references to "romdb_editor.exe", "Runes.Net.Shared.dll" and "Runes.Net.Db.dll".
Then paste code written above in Class1.cs and now you can write code.
Note you are only writing a body for that method.
However, you can also hack it using code like following:
Code:
// SOME CODE - Run method`s body
}
static void RETURN_TYPE FUNC_NAME(ARGS){//other method`s body
}
and so on.
Please, do not use things that can cause any kind of unhandled exception too easily. Debuging could be not simple at all.
If you hadn`t got it yet - you shouldn`t compile anything, just copy method`s body to editor and click Run.

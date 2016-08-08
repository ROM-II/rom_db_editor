#include "structs.h"
#include <stdio.h>
#include <iostream>


int main()
{
	union
	{
		byte rowbytes[1736];
		GameObjDbStruct dbobj;
	} object;
	FILE* f;
	fopen_s(&f, "c:\\runewaker\\runes of magic\\data\\armorobject.db", "rb");
	fseek(f, 140, 0);
	do
	{
		fread(object.rowbytes, 1736, 1, f);
	} while (object.dbobj.GUID != 2200002 || !feof(f));
	auto addrBase = (byte*)&object;
	auto addrField = (byte*)&object.dbobj.AsOther.Item.IsFixDurable;
	std::cout << (int)addrBase << " " << (int)addrField << " : " << (int)(addrField - addrBase);

	fclose(f);
	return 0;
}
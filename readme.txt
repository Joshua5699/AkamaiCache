If you're familiar with Akamai, then most everyting here should be straightforward.
This is the same functionality as a direct call to the web service, only a
little easier to install and maintain.

There's a pretty good explination of the service itself, here:  http://www.codeproject.com/Articles/186089/How-to-Purge-Cache-in-Akamai-Proxy-Server-using-C

Most of the enums in this project reflect the values passed to the service and are basically straightforward.
The only thing that might merit some explination: If the "PurgeType" is set to "CPCode", then the first item in the "itemstopurge" array must be a number.  If the "PurgeType" is set to "ARL", then the then the first item in the "itemstopurge" array must contain "http://" or "https://".  This is more or less a direct reflection of the way the service works (with the "itemsToPurge" collection either containing the CPCode or URLS).

Once compiled, you can call it like so:

RemoveItems removeItems = new RemoveItems();
removeItems.Action = Akamai.Action.Invalidate;
removeItems.Domain = Domain.Production;
removeItems.PurgeType = PurgeType.CPCode;
removeItems.AkamaiAccountName = "<youraccount>";
removeItems.AkamaiAccountPassword = "<yourpassword>";
removeItems.AkamaiNotificationEmail = "<yournotificationemail>";
string[] itemstoRemove = new string[1] { "<yourcpcode>" };
removeItems.ItemsToPurge = itemstoRemove;
removeItems.Remove();
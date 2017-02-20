#region License
/*================================================================
Product:    LocalizationManager
Developer:  Onur Tanrıkulu
Company:    Onur Tanrikulu
Date:       24/01/2017 17:17

Copyright (c) 2017 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using System;

[Serializable]
public class LocalizationData
{
    public LocalizationItem[] items;
}

[Serializable]
public class LocalizationItem
{
    public string key;
    public string text;
}

using Slash.Unity.DataBind.Core.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterContext : Context
{
    private readonly Property<GoldContext> goldProperty =
        new Property<GoldContext>();
    public GoldContext Gold
    {
        get
        {
            return goldProperty.Value;
        }
        set
        {
            goldProperty.Value = value;
        }
    }
    private MasterContext()
    {

    }
}
public class GoldContext : Context
{
    private readonly Property<string> goldStringProperty =
        new Property<string>();
    public string GoldString
    {
        get
        {
            return goldStringProperty.Value;
        }
        set
        {
            goldStringProperty.Value = value;
        }
    }
}

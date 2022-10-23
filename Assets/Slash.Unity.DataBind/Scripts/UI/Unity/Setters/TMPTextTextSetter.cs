// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextTextSetter.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Slash.Unity.DataBind.UI.Unity.Setters
{
    using Slash.Unity.DataBind.Foundation.Setters;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    ///   Set the text of a Text depending on the string data value.
    /// </summary>
    [AddComponentMenu("Data Bind/UnityUI/Setters/[DB]TMP Text Text Setter (Unity)")]
    public class TMPTextTextSetter : ComponentSingleSetter<TMP_Text, string>
    {
        /// <inheritdoc />
        protected override void UpdateTargetValue(TMP_Text target, string value)
        {
            target.text = value;
        }
    }
}
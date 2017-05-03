
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
//using System.Data;
using System.Diagnostics;
/// <summary>
/// The different AI levels.
/// </summary>
public enum AIOption
{
	/// <summary>
	/// Easy, total random shooting
	/// </summary>
	easy,

	/// <summary>
	/// Medium, marks squares around hits
	/// </summary>
	medium,

	/// <summary>
	/// As medium, but removes shots once it misses
	/// </summary>
	hard,
}

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================

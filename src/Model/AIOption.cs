
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
	AIPlayer,

	/// <summary>
	/// Medium, marks squares around hits
	/// </summary>
	AIMediumPlayer,

	/// <summary>
	/// As medium, but removes shots once it misses
	/// </summary>
	AIHardPlayer,
}

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================

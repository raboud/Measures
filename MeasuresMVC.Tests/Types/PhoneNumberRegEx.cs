using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandREng.Types;

namespace MeasuresMVC.Tests.Types
{
	[TestClass]
	public class PhoneNumberRegEx
	{
		[TestMethod]
		public void PhoneNumberRegExRegEx1()
		{
			string input = "234.567.8901 ext 8888";
			bool b = Regex.IsMatch(input, PhoneNumber10Ext.RegEx, RegexOptions.IgnoreCase);
			Assert.IsTrue(b, input);
			string t = PhoneNumber10Ext.Reformat(input);
			Assert.AreEqual(t, "(234) 567-8901 ext 8888");
		}
		[TestMethod]
		public void PhoneNumberRegExRegEx2()
		{
			string input = "(234)567.8901 ext 8888";
			bool b = Regex.IsMatch(input, PhoneNumber10Ext.RegEx, RegexOptions.IgnoreCase);
			Assert.IsTrue(b, input);
			string t = PhoneNumber10Ext.Reformat(input);
			Assert.AreEqual(t, "(234) 567-8901 ext 8888");
		}
		[TestMethod]
		public void PhoneNumberRegExRegEx3()
		{
			string input = "(234) 567.8901 ext 8888";
			bool b = Regex.IsMatch(input, PhoneNumber10Ext.RegEx, RegexOptions.IgnoreCase);
			Assert.IsTrue(b, input);
			string t = PhoneNumber10Ext.Reformat(input);
			Assert.AreEqual(t, "(234) 567-8901 ext 8888");
		}
		[TestMethod]
		public void PhoneNumberRegExRegEx4()
		{
			string input = "234.567.8901 ext 9ii";
			bool b = Regex.IsMatch(input, PhoneNumber10Ext.RegEx, RegexOptions.IgnoreCase);
			Assert.IsFalse(b, input);
			string t = PhoneNumber10Ext.Reformat(input);
			Assert.AreEqual(t, "ERROR");
		}
		[TestMethod]
		public void PhoneNumberRegExRegEx()
		{
			string input = "aaa.567.8901 ext 8888";
			bool b = Regex.IsMatch(input, PhoneNumber10Ext.RegEx, RegexOptions.IgnoreCase);
			Assert.IsFalse(b, input);
			string t = PhoneNumber10Ext.Reformat(input);
			Assert.AreEqual(t, "ERROR");
		}
		[TestMethod]
		public void PhoneNumberRegEx6()
		{
			string input = "234.567.8901 x 8888";
			bool b = Regex.IsMatch(input, PhoneNumber10Ext.RegEx, RegexOptions.IgnoreCase);
			Assert.IsTrue(b, input);
			string t = PhoneNumber10Ext.Reformat(input);
			Assert.AreEqual(t, "(234) 567-8901 ext 8888");
		}

		[TestMethod]
		public void PhoneNumberRegEx7()
		{
			string input = "234.567.8901 x8888";
			bool b = Regex.IsMatch(input, PhoneNumber10Ext.RegEx, RegexOptions.IgnoreCase);
			Assert.IsTrue(b, input);
			string t = PhoneNumber10Ext.Reformat(input);
			Assert.AreEqual(t, "(234) 567-8901 ext 8888");
		}
		[TestMethod]
		public void PhoneNumberRegEx8()
		{
			string input = "234.567.8901x8888";
			bool b = Regex.IsMatch(input, PhoneNumber10Ext.RegEx, RegexOptions.IgnoreCase);
			Assert.IsTrue(b, input);
			string t = PhoneNumber10Ext.Reformat(input);
			Assert.AreEqual(t, "(234) 567-8901 ext 8888");
		}
		[TestMethod]
		public void PhoneNumberRegEx9()
		{
			string input = "234.567.8901 ext. 8888";
			bool b = Regex.IsMatch(input, PhoneNumber10Ext.RegEx, RegexOptions.IgnoreCase);
			Assert.IsTrue(b, input);
			string t = PhoneNumber10Ext.Reformat(input);
			Assert.AreEqual(t, "(234) 567-8901 ext 8888");
		}
		[TestMethod]
		public void PhoneNumberRegEx10()
		{
			string input = "234.567.8901 ext8888";
			bool b = Regex.IsMatch(input, PhoneNumber10Ext.RegEx, RegexOptions.IgnoreCase);
			Assert.IsTrue(b, input);
			string t = PhoneNumber10Ext.Reformat(input);
			Assert.AreEqual(t, "(234) 567-8901 ext 8888");
		}
		[TestMethod]
		public void PhoneNumberRegEx11()
		{
			string input = "234.567.8901 ext 8888";
			bool b = Regex.IsMatch(input, PhoneNumber10.RegEx, RegexOptions.IgnoreCase);
			Assert.IsFalse(b, input);
			string t = PhoneNumber10.Reformat(input);
			Assert.AreEqual(t, "ERROR");
		}
		[TestMethod]
		public void PhoneNumberRegEx12()
		{
			string input = "234.567.8901 ";
			bool b = Regex.IsMatch(input, PhoneNumber10.RegEx, RegexOptions.IgnoreCase);
			Assert.IsFalse(b, input);
			string t = PhoneNumber10.Reformat(input);
			Assert.AreEqual(t, "ERROR");
		}
		[TestMethod]
		public void PhoneNumberRegEx13()
		{
			string input = "234.567.8901";
			bool b = Regex.IsMatch(input, PhoneNumber10.RegEx, RegexOptions.IgnoreCase);
			Assert.IsTrue(b, input);
			string t = PhoneNumber10.Reformat(input);
			Assert.AreEqual(t, "(234) 567-8901");
		}
		[TestMethod]
		public void PhoneNumberRegEx14()
		{
			string input = "234.567-8901 ext 8888";
			bool b = Regex.IsMatch(input, PhoneNumber10Ext.RegEx, RegexOptions.IgnoreCase);
			Assert.IsTrue(b, input);
			string t = PhoneNumber10Ext.Reformat(input);
			Assert.AreEqual(t, "(234) 567-8901 ext 8888");
		}
		[TestMethod]
		public void PhoneNumberRegEx15()
		{
			string input = "24.567.8901 ext 8888";
			bool b = Regex.IsMatch(input, PhoneNumber10Ext.RegEx, RegexOptions.IgnoreCase);
			Assert.IsFalse(b, input);
			string t = PhoneNumber10Ext.Reformat(input);
			Assert.AreEqual(t, "ERROR");
		}
		[TestMethod]
		public void PhoneNumberRegEx16()
		{
			string input = "234.567.8901";
			bool b = Regex.IsMatch(input, PhoneNumber10Ext.RegEx, RegexOptions.IgnoreCase);
			Assert.IsTrue(b, input);
			string t = PhoneNumber10Ext.Reformat(input);
			Assert.AreEqual(t, "(234) 567-8901");
		}
	}
}

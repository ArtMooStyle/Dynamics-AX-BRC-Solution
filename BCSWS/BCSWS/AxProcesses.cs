using Microsoft.Dynamics.BusinessConnectorNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Net;
using System.Xml;

public class AxProcesses
{
	private Axapta ax;

	public AxProcesses()
	{
		this.ax = new Axapta();
	}

	public static string[] call(List<object> parameters)
	{
		string[] arrayString = null;
		AxProcesses axProcess = null;
		try
		{
			axProcess = new AxProcesses();
			string str = axProcess.callAxMethod(parameters);
			arrayString = axProcess.convertXmlStringToArrayString(str);
		}
		catch (Exception exception1)
		{
			Exception exception = exception1;
			if (axProcess != null)
			{
				axProcess.logoutAx();
			}
            arrayString = new string[1];
            arrayString[0] = exception1.Message;
			//throw exception;
		}
		return arrayString;
	}

	private string callAxMethod(List<object> parameters)
	{
        try
        {
            this.loginToAx();
            AxaptaContainer axaptaContainer = this.convertList2Container(parameters);
            string str = "";
            object res = this.ax.CallStaticClassMethod("BCSBase", "call", axaptaContainer);
            if (res is string)
                str = (string)res;
            else
                throw new Exception(String.Format("[Exception] ax.CallStaticClassMethod(BCSBase) doesn't return string. Parameters: {0}", axaptaContainer));
            this.logoutAx();
            return str;
        }
        catch (Exception exception1)
        {
            throw new Exception(String.Format("[Exception] callAxMethod: {0}", exception1.Message));
        }
	}

	private AxaptaContainer convertList2Container(List<object> parameters)
	{
        try
        {
		    AxaptaContainer axaptaContainer = this.ax.CreateAxaptaContainer();
		    foreach (object parameter in parameters)
		    {
			    if (!(parameter is int))
			    {
				    if (!(parameter is double))
				    {
					    if (!(parameter is string))
					    {
					        if (!(parameter is bool))
					        {
						        if (!(parameter is DateTime))
						        {
							        string str = "Wrong input parameters, should be int, double, string, bool or DateTime. Type is {0}";
							        str = string.Format(str, parameter.GetType().FullName);
							        throw new Exception(str);
						        }
						        else
						        {
							        DateTime dateTime = (DateTime)parameter;
							        axaptaContainer.Add(dateTime.ToString());
						        }
                            }
                            else
                            {
                                axaptaContainer.Add((bool)parameter);
                            }
                        }
					    else
					    {
						    axaptaContainer.Add((string)parameter);
					    }
				    }
				    else
				    {
					    axaptaContainer.Add((double)parameter);
				    }
			    }
			    else
			    {
				    axaptaContainer.Add((int)parameter);
			    }
		    }
		    return axaptaContainer;
        }
        catch (Exception exception1)
        {
            throw new Exception(String.Format("[Exception] convertList2Container: {0}", exception1.Message));
        }
    }

	private string[] convertXmlStringToArrayString(string xml)
	{
		XmlDocument xmlDocument = new XmlDocument();
		int num = 0;
		xmlDocument.LoadXml(xml);
		XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("element");
		string[] innerText = new string[elementsByTagName.Count];
		foreach (XmlElement xmlElement in elementsByTagName)
		{
			innerText[num] = xmlElement.InnerText;
			num++;
		}
		return innerText;
	}

	private void loginToAx()
	{
        try
        {
            string str = ConfigurationManager.AppSettings.Get("User");
		    string str1 = ConfigurationManager.AppSettings.Get("PWD");
		    string str2 = ConfigurationManager.AppSettings.Get("Domain");
		    string str3 = ConfigurationManager.AppSettings.Get("Company");
		    string str4 = ConfigurationManager.AppSettings.Get("Instance");
		    NetworkCredential networkCredential = new NetworkCredential(str, str1, str2);
		    this.ax.LogonAs(str, str2, networkCredential, str3, null, str4, null);
		    this.ax.Refresh();
            /*
		    AxaptaContainer axaptaContainer = this.ax.CreateAxaptaContainer();
		    axaptaContainer.Add(0);
		    axaptaContainer.Add("login");
		    axaptaContainer.Add(DateTime.Now);
            string str5 = (string)this.ax.CallStaticClassMethod("BCSBase", "call", axaptaContainer);
		    this.ax.Logoff();
		    this.ax.LogonAs(str5, str2, networkCredential, str3, null, str4, null);
		    this.ax.Refresh();
            */ 
        }
        catch (Exception exception1)
        {
            throw new Exception(String.Format("[Exception] loginToAx: {0}", exception1.Message));
        }
	}

	private void logoutAx()
	{
		this.ax.Logoff();
	}
}
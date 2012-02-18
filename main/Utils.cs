using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.Xml;
using System.Net;
using System.Net.Mail;

namespace EgidaBackup
{
	public class Utils
	{
		public static void RunProcess(string exe, string args)
		{
			Process proc = new Process();
			proc.StartInfo.FileName = exe;
			proc.StartInfo.Arguments = args;
			proc.Start();
			proc.WaitForExit();
			proc.Dispose();
		}

        public static void RunProcess(string exe, string args, ref string Output)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = exe;
            proc.StartInfo.Arguments = args;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.Start();
            proc.WaitForExit();
            Output = proc.StandardOutput.ReadToEnd();
            proc.Dispose(); 
        }

		public static void CopyFile(string source, string dest, LogBackupInterface Log)
		{
			int CopyBufferSize = 32768;
			bool NeedCopy = false;
			if (File.Exists(dest))
			{
				if (File.GetLastWriteTime(source) > File.GetLastWriteTime(dest))
					NeedCopy = true;
			}
			else
				NeedCopy = true;
			if (NeedCopy)
			{
				FileStream s = new FileStream(source, FileMode.Open, FileAccess.Read, FileShare.Read);
				long size = s.Length;
				long readed = 0;
				FileStream d = File.Create(dest);
				byte[] buffer = new byte[CopyBufferSize];
				int sourcebyte;
				do
				{
					sourcebyte = s.Read(buffer, 0, buffer.Length);
					d.Write(buffer, 0, sourcebyte);
					readed += sourcebyte;
					if (Log != null)
						Log.InvokeSetProgress((int)(((float)readed / (float)size) * 100));
				}
				while (sourcebyte > 0);
				s.Close();
				d.Close();
				s.Dispose();
				d.Dispose();
			}
		}

		public static void KillProcess(string ProcessName, bool Kill)
		{
			DateTime beginkill = DateTime.Now;
			Process[] Processes = Process.GetProcessesByName(ProcessName);
			foreach (Process P in Processes)
			{
				MessageBox.Show("Необходимо выполнить резервное копирование. Программа " + P.ProcessName + " должна быть закрыта.");
				P.CloseMainWindow();
			}
			while (Processes.Length > 0)
			{
				Processes = Process.GetProcessesByName(ProcessName);
				if (Processes.Length > 0)
				{
					if ((DateTime.Now - beginkill).TotalSeconds < 60)
						Thread.Sleep(1000);
					else
					{
						if (Kill)
							foreach (Process P in Processes)
								P.Kill();
						break;
					}
				}
			}
		}

		public static void DisconnectUsers1C81(TaskItem Task, bool ClientServer, string Server1C, string ServerBase, string User1C, string Pass1C, bool KillUsers, LogBackupInterface Log)
		{
			try
			{
				if (ClientServer)
				{
					/*V81.COMConnectorClass Connector = new V81.COMConnectorClass();
					V81.IServerAgentConnection Agent = Connector.ConnectAgent(Server1C);
					V81.IClusterInfo Cluster = (V81.IClusterInfo)(Agent.GetClusters().GetValue(0));
					Agent.Authenticate(Cluster, "", "");
					V81.IWorkingProcessInfo WorkingProcess = (V81.IWorkingProcessInfo)Agent.GetWorkingProcesses(Cluster).GetValue(0);
					string ConnectionString = WorkingProcess.HostName + ":" + WorkingProcess.MainPort;
					V81.IWorkingProcessConnection WorkingProcessConnection = Connector.ConnectWorkingProcess(ConnectionString);
					WorkingProcessConnection.AddAuthentication(User1C, Pass1C);
					V81.IInfoBaseInfo Desc = WorkingProcessConnection.CreateInfoBaseInfo();
					Desc.Name = ServerBase;
					Array Connections = WorkingProcessConnection.GetInfoBaseConnections(Desc);
					foreach (V81.IInfoBaseConnectionInfo C in Connections)
					{
                        if (C.AppID != "COMConsole")
                        {
                            WorkingProcessConnection.Disconnect(C);
                        }
					}
					Log.InvokeAddLogItem(Task, "Пользователи отключены", LogItemType.Warning);*/
                    string Output = "";
                    Utils.RunProcess(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "disconnect1c.exe"), 
                        "8.1 "+Server1C+" "+ServerBase+" "+User1C+" "+Pass1C, ref Output);
                    if (Output!="")
                        Log.InvokeAddLogItem(Task, Output, LogItemType.Warning);
                    else
                        Log.InvokeAddLogItem(Task, "Пользователи отключены", LogItemType.Warning);
				}
				else
				{
					KillProcess("1cv8", KillUsers);
					Log.InvokeAddLogItem(Task, "Пользователи отключены", LogItemType.Warning);
				}
			}
			catch (Exception ex)
			{
				if (Log != null)
					Log.InvokeAddLogItem(Task, "Отключение пользователей: "+ex.Message, LogItemType.Error);
			}
		}

        public static void DisconnectUsers1C82(TaskItem Task, bool ClientServer, string Server1C, string ServerBase, string User1C, string Pass1C, bool KillUsers, LogBackupInterface Log)
        {
            try
            {
                if (ClientServer)
                {
                    /*V81.COMConnectorClass Connector = new V81.COMConnectorClass();
                    V81.IServerAgentConnection Agent = Connector.ConnectAgent(Server1C);
                    V81.IClusterInfo Cluster = (V81.IClusterInfo)(Agent.GetClusters().GetValue(0));
                    Agent.Authenticate(Cluster, "", "");
                    V81.IWorkingProcessInfo WorkingProcess = (V81.IWorkingProcessInfo)Agent.GetWorkingProcesses(Cluster).GetValue(0);
                    string ConnectionString = WorkingProcess.HostName + ":" + WorkingProcess.MainPort;
                    V81.IWorkingProcessConnection WorkingProcessConnection = Connector.ConnectWorkingProcess(ConnectionString);
                    WorkingProcessConnection.AddAuthentication(User1C, Pass1C);
                    V81.IInfoBaseInfo Desc = WorkingProcessConnection.CreateInfoBaseInfo();
                    Desc.Name = ServerBase;
                    Array Connections = WorkingProcessConnection.GetInfoBaseConnections(Desc);
                    foreach (V81.IInfoBaseConnectionInfo C in Connections)
                    {
                        if (C.AppID != "COMConsole")
                        {
                            WorkingProcessConnection.Disconnect(C);
                        }
                    }
                    Log.InvokeAddLogItem(Task, "Пользователи отключены", LogItemType.Warning);*/
                    string Output = "";
                    Utils.RunProcess(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "disconnect1c.exe"),
                        "8.2 " + Server1C + " " + ServerBase + " " + User1C + " " + Pass1C, ref Output);
                    if (Output != "")
                        Log.InvokeAddLogItem(Task, Output, LogItemType.Warning);
                    else
                        Log.InvokeAddLogItem(Task, "Пользователи отключены", LogItemType.Warning);
                }
                else
                {
                    KillProcess("1cv8", KillUsers);
                    Log.InvokeAddLogItem(Task, "Пользователи отключены", LogItemType.Warning);
                }
            }
            catch (Exception ex)
            {
                if (Log != null)
                    Log.InvokeAddLogItem(Task, "Отключение пользователей: " + ex.Message, LogItemType.Error);
            }
        }

		public static void DisconnectUsers1C7(TaskItem Task, bool ClientServer, bool KillUsers, LogBackupInterface Log)
		{
			try
			{
				if (ClientServer)
				{


				}
				else
				{
					Utils.KillProcess("1cv7", KillUsers);
					Utils.KillProcess("1cv7s", KillUsers);
					Log.InvokeAddLogItem(Task, "Пользователи отключены", LogItemType.Warning);
				}
			}
			catch (Exception ex)
			{
                Log.InvokeAddLogItem(Task, "Отключение пользователей: " + ex.Message, LogItemType.Error);
			}
		}

		public static void DisconnectUsers1C8(TaskItem Task, bool ClientServer, string Server1C, string ServerBase, string User1C, string Pass1C, bool KillUsers, LogBackupInterface Log)
		{
			try
			{
				if (ClientServer)
				{
					/*V8.COMConnectorClass Connector = new V8.COMConnectorClass();
					V8.IV8ServerConnection Server = Connector.ConnectServer(Server1C);
					Server.AddAuthentication(User1C, Pass1C);
					V8.IInfoBaseInfo Desc = Server.CreateInfoBaseInfo();
					Desc.Name = ServerBase;
					Array Connections = Server.GetIBConnections(Desc);
					foreach (V8.IIBConnectionInfo C in Connections)
					{
						Server.Disconnect(C);
					}
					Log.InvokeAddLogItem(Task, "Пользователи отключены", LogItemType.Warning);*/
                    string Output = "";
                    Utils.RunProcess(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "disconnect1c.exe"),
                        "8.0 " + Server1C + " " + ServerBase + " " + User1C + " " + Pass1C, ref Output);
                    if (Output != "")
                        Log.InvokeAddLogItem(Task, Output, LogItemType.Warning);
                    else
                        Log.InvokeAddLogItem(Task, "Пользователи отключены", LogItemType.Warning);
				}
				else
				{
					Utils.KillProcess("1cv8", KillUsers);
					Log.InvokeAddLogItem(Task, "Пользователи отключены", LogItemType.Warning);
				}

			}
			catch (Exception ex)
			{
                Log.InvokeAddLogItem(Task, "Отключение пользователей: " + ex.Message, LogItemType.Error);
			}
		}

		static ArrayList GenerateFiles(string PathString, string FileMask, SearchOption SO)
		{
			if (FileMask == "")
				FileMask = "*.*";
			ArrayList Files = new ArrayList();
			string[] Masks = FileMask.Split(';');
			foreach (string M in Masks)
				Files.AddRange(Directory.GetFiles(PathString, M.Trim(), SO));
			return Files;
		}

		public static bool CopyDirectory(TaskItem Task, string source, string dest, string Mask, LogBackupInterface Log)
		{
			int current = 0;
			int count = GenerateFiles(source, Mask, SearchOption.AllDirectories).Count;
			Log.InvokeAddLogItem(Task, "Начало копирования каталога " + source, LogItemType.Information);
			return CopyDirectory(Task, source, dest, Mask, count, ref current, Log);
		}

		static bool CopyDirectory(TaskItem Task, string source, string dest, string Mask, int count, ref int current, LogBackupInterface Log)
		{
			try
			{
				Directory.CreateDirectory(dest);
				string[] dirs = Directory.GetDirectories(source);
				ArrayList files = GenerateFiles(source, Mask, SearchOption.TopDirectoryOnly);
				foreach (string file in files)
				{
					Log.InvokeSetStatusLabel(file);
					Utils.CopyFile(file, System.IO.Path.Combine(dest, System.IO.Path.GetFileName(file)), null);
					current++;
					Log.InvokeSetProgress((int)((float)current / (float)count * 100.0f));
				}
				foreach (string dir in dirs)
				{
					CopyDirectory(Task, dir, System.IO.Path.Combine(dest, System.IO.Path.GetFileName(dir)), Mask, count, ref current, Log);
				}
				return true;
			}
			catch (Exception ex)
			{
                Log.InvokeAddLogItem(Task, "Копирование директории: " + ex.Message, LogItemType.Error);
				return false;
			}
		}

        public static void SendMail(TaskItem Task, string Subject, string Body, LogBackupInterface Log)
        {
            try
            {
                SmtpClient Mail = new SmtpClient();
                Mail.Host = Program.Options["Notice.SMTP"].AsString;
                Mail.Credentials = new NetworkCredential(Program.Options["Notice.Login"].AsString, Program.Options["Notice.Pass"].AsString);
                MailMessage Message = new MailMessage(Program.Options["Notice.Sender"].AsString, Program.Options["Notice.Mailto"].AsString, Subject, Body);
                Message.BodyEncoding = Encoding.UTF8;
                Message.IsBodyHtml = true;
                Mail.Send(Message);
            }
            catch (Exception ex)
            {
                Log.InvokeAddLogItem(Task, "Уведомление: " + ex.Message, LogItemType.Error);
            }
        }
	}

    public class XMLUtils
    {
        public static string GetAttr(XmlNode Node, string AttrName)
        {
            if (Node.Attributes[AttrName] != null)
            {
                return Node.Attributes[AttrName].Value;
            }
            else
                return "";
        }
    }
}

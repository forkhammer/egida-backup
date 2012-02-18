program Disconnect1C;

uses
  SysUtils,
  ComObj,
  Variants;

{$R *.res}

var
    Connector, Agent, Clusters, Cluster, WorkingProcesses, WorkingProcess,
    Desc, WorkingProcessConnection, C, Server:variant;
    Connections:array of variant;
    ConnectionString:string;
    i, l:integer;

    Version1C, Server1C, ServerBase, User, Pass:string;

begin
Version1C:=ParamStr(1);
Server1C:=ParamStr(2);
ServerBase:=ParamStr(3);
if ParamCount>=4 then
    User:=ParamStr(4);
if ParamCount>=5 then
    Pass:=ParamStr(5);
if Version1C='8.1' then
    begin
    try
    CoInitializeEx(nil, 0);
    Connector:=CreateOleObject('V81.COMConnector');
    Agent := Connector.ConnectAgent(Server1C);
    Clusters := Agent.GetClusters;
    Cluster:=Clusters[0];
    Agent.Authenticate(Cluster, '', '');
    WorkingProcesses := Agent.GetWorkingProcesses(Cluster);
    WorkingProcess:=WorkingProcesses[0];
    ConnectionString := VarToStr(WorkingProcess.HostName) + ':' + VarToStr(WorkingProcess.MainPort);
    WorkingProcessConnection := Connector.ConnectWorkingProcess(ConnectionString);
    WorkingProcessConnection.AddAuthentication(User, Pass);
    Desc := WorkingProcessConnection.CreateInfoBaseInfo;
    Desc.Name := ServerBase;
    Connections := WorkingProcessConnection.GetInfoBaseConnections(Desc);
    l:=high(Connections);
    for I := 0 to l do
        begin
        C:=Connections[i];
        if C.AppID<>'COMConsole' then
            WorkingProcessConnection.Disconnect(C);
        end;
    except
        on e:Exception do
            Writeln(e.Message);
    end;
    end;

if Version1C='8.2' then
    begin
    try
    CoInitializeEx(nil, 0);
    Connector:=CreateOleObject('V82.COMConnector');
    Agent := Connector.ConnectAgent(Server1C);
    Clusters := Agent.GetClusters;
    Cluster:=Clusters[0];
    Agent.Authenticate(Cluster, '', '');
    WorkingProcesses := Agent.GetWorkingProcesses(Cluster);
    WorkingProcess:=WorkingProcesses[0];
    ConnectionString := VarToStr(WorkingProcess.HostName) + ':' + VarToStr(WorkingProcess.MainPort);
    WorkingProcessConnection := Connector.ConnectWorkingProcess(ConnectionString);
    WorkingProcessConnection.AddAuthentication(User, Pass);
    Desc := WorkingProcessConnection.CreateInfoBaseInfo;
    Desc.Name := ServerBase;
    Connections := WorkingProcessConnection.GetInfoBaseConnections(Desc);
    l:=high(Connections);
    for I := 0 to l do
        begin
        C:=Connections[i];
        if C.AppID<>'COMConsole' then
            WorkingProcessConnection.Disconnect(C);
        end;
    except
        on e:Exception do
            Writeln(e.Message);
    end;
    end;

if Version1C='8.0' then
    begin
    try
    Connector := CreateOleObject('V8.COMConnector');
	Server := Connector.ConnectServer(Server1C);
	Server.AddAuthentication(User, Pass);
	Desc := Server.CreateInfoBaseInfo;
	Desc.Name := ServerBase;
	Connections := Server.GetIBConnections(Desc);
    l:=high(Connections);
    for I := 0 to l do
        begin
        Server.Disconnect(C);
        end;
    except
        on e:Exception do
            Writeln(e.Message);
    end;
    end;
end.

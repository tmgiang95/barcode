Declare @AppID int;
select @AppID = ID from ApplicationDefinition where App_ID_Name = 'APP_0000_MAIN_FORM'
Declare @CodeGroupID int;		   
select @CodeGroupID = ID from AppGroupGUIDefinition where CODEGROUP = 'APP_0000_GUI_MAIN_FORM' and AppID = @AppID

--Msg close form text
IF NOT EXISTS(SELECT * From AppCodeGUIDefinition WHERE CODE = 'MSG_Close_App_Text' and LANGUAGE = 'EN' and OBJECT = 'Text' and AppID = @AppID And CodeGroupGUI = @CodeGroupID)
	BEGIN
		insert into AppCodeGUIDefinition values(@AppID,@CodeGroupID,'qBASEHistoryBtnAccept','Accept Changes','Text','EN','XXXX',1,NULL,0,0,NULL,getdate())
	END
ELSE
	BEGIN
		UPDATE AppCodeGUIDefinition SET DESCRIPTION = 'Accept Changes' WHERE  CODE = 'qBASEHistoryBtnAccept' and LANGUAGE = 'EN' and OBJECT = 'Text' and FK_App_ID = @AppID And FK_CODEGROUP_ID = @CodeGroupID
	END

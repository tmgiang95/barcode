SET @AppID int;
select @AppID = ID from ApplicationDefinition where App_ID_Name = 'APP_0000_MAIN_FORM'
SET @CodeGroupID int;		   
select @CodeGroupID = ID from AppGroupGUIDefinition where CODEGROUP = 'APP_0000_GUI_MAIN_FORM' and AppID = @AppID

--Msg close form text
IF NOT EXISTS(SELECT * From AppCodeGUIDefinition WHERE CODE = 'MSG_Close_App_Text' and LANGUAGE = 'EN' and OBJECT = 'Text' and AppID = @AppID And CodeGroupGUI = @CodeGroupID)
	BEGIN
		insert into AppCodeGUIDefinition values(@AppID,@CodeGroupID,'MSG_Close_App_Text','Text','EN','Are you sure to exit {0} application',1)
	END
ELSE
	BEGIN
		UPDATE AppCodeGUIDefinition SET Description = 'Are you sure to exit {0} application' WHERE  CODE = 'MSG_Close_App_Text' and LANGUAGE = 'EN' and OBJECT = 'Text' and AppID = @AppID And CodeGroupGUI = @CodeGroupID
	END

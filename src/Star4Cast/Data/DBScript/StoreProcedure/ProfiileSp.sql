IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'SelectSocialAddress')
			AND type IN (
				N'P',
				N'PC'
				)
		)
	DROP PROCEDURE SelectSocialAddress
GO

CREATE PROCEDURE SelectSocialAddress (@UserID NVARCHAR(450))
AS
BEGIN
	BEGIN TRY
		--SELECT *
		--FROM SocialAddress SA
		--LEFT JOIN UserSocialAddress USA
		--	ON USA.SocialAddressId = SA.Id
		--		AND USA.STATUS = 1
		--		AND USA.UserId = @UserID
		SELECT USA.Id AS UserSocialAddressId, SA.Id as SocialAddressId, USA.Status, 
				SocialUserName, SocialName, PreUrl, PostUrl, PostLabel, HelpUrl, IconClass
		FROM SocialAddress SA
		LEFT OUTER JOIN UserSocialAddress USA
		ON USA.SocialAddressId = SA.Id
			AND USA.STATUS = 1
			AND USA.UserId = @UserID
	END TRY

	BEGIN CATCH
		--INSERT INTO ErrorLog (
		--	ErrorType,
		--	ErrorName,
		--	CustomMesage,
		--	ErrorNumber,
		--	ErrorMessage
		--	)
		--VALUES (
		--	1,
		--	'Select20InterNews',
		--	'Error from Select20InterNews Store Procedure',
		--	ERROR_NUMBER(),
		--	ERROR_MESSAGE()
		--	)
	END CATCH
END
	--EXEC SelectSocialAddress '564f2b04-0eda-4a14-b2df-21fa24eef10f'

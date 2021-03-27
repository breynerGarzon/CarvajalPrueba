namespace Carvajal.Prueba.Helper.StoreProcedure
{
    public static class Definitions
    {
        public static string QUERY_CREATE_SP_CREATEUSER = $@"
        CREATE PROCEDURE 
        [dbo].{StoreProcedureName.ADDUSER}
            @DocumentNumber  varchar(80),
            @Names varchar(80),
            @LastNames varchar(80),
            @Password varchar(80),
            @Mail varchar(80),
            @DocumentType int
        AS 
            Declare @isAlredyRegister int

            Select @isAlredyRegister =  COUNT(*)
            from Persons as pe
            Where pe.Mail = @Mail
            OR pe.Id = @DocumentNumber

            IF(@isAlredyRegister>0)
                Select 'El mail ya esta registrado en el sistema';
            Else
                Insert Into Persons Values (@DocumentNumber,@Names, @LastNames,@Password, @Mail, @DocumentType);
                Select 
                pe.Name as Name, pe.LastName as LastName, pe.Mail as Mail, pe.Id as DocumentNumber, pe.DocumentTypeId as DocumentType
                from Persons as pe
                Where pe.Id = @DocumentNumber;
        GO";

        public static string QUERY_CREATE_SP_UPDATEUSER = $@"
        Create procedure [dbo].{StoreProcedureName.UPDATEUSER}
            @DocumentNumber  varchar(80),
            @Names varchar(80),
            @LastNames varchar(80),
            @Password varchar(80),
            @Mail varchar(80),
            @DocumentType int
            as 
                Declare @isAlredyRegister int

                Select @isAlredyRegister =  COUNT(*)
                from Persons as pe
                Where pe.Mail = @Mail 
                And pe.Id <> @DocumentNumber

                IF(@isAlredyRegister>0)
                    Select 'El mail ya esta registrado en el sistema a otra persona';
                Else
                    Update Persons SET Name = @Names, LastName = @LastNames, PassWord = @Password, Mail=@Mail, DocumentTypeId = @DocumentType 
                    Where Id = @DocumentNumber;
;
        GO";
    
        public static string QUERY_CREATE_SP_DELETEUSER = $@"
        Create procedure [dbo].{StoreProcedureName.DELETEUSER}
        @DocumentNumber  varchar(80)
        as 
        Delete From Persons Where Id = @DocumentNumber;
        GO";

        public static string QUERY_CREATE_SP_GETUSER = $@"
        Create procedure [dbo].{StoreProcedureName.GETUSERS}
            as 
        Select 
            pe.Name as Name, pe.LastName as LastName, pe.Mail as Mail, pe.Id as DocumentNumber, pe.DocumentTypeId as DocumentType
        from Persons as pe;
        GO";

        public static string QUERY_CREATE_SP_GETDOCUMENTTYPE = $@"
        Create procedure [dbo].{StoreProcedureName.GETDOCUMENTSTYPE}
            as 
        Select 
            pT.Id as Id, pT.Name as Description 
        From PersonTypes pT
        GO";
    
    
    }
}
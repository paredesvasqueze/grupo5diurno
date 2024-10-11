create PROCEDURE USP_Delete_Pago
    @nIdPago INT
AS
BEGIN
    DELETE FROM Pago
    WHERE nIdPago = @nIdPago;
END;

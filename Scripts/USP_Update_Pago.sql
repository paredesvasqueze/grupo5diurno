create PROCEDURE USP_Update_Pago
    @nIdPago INT,
    @nIdUsuario INT,
    @nIdSuscripcion INT,
    @nMonto INT,
    @dFechaPago DATETIME,
    @cMetodoPago NVARCHAR(50) = NULL
AS
BEGIN
    UPDATE Pago
    SET nIdUsuario = @nIdUsuario,
        nIdSuscripcion = @nIdSuscripcion,
        nMonto = @nMonto,
        dFechaPago = @dFechaPago,
        cMetodoPago = @cMetodoPago
    WHERE nIdPago = @nIdPago;
END;

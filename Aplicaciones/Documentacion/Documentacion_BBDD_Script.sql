USE [AutobusesSese]
GO
/****** Object:  Table [dbo].[Ciudades]    Script Date: 30/04/2019 16:40:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciudades](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreCiudad] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Ciudades] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rutas]    Script Date: 30/04/2019 16:40:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rutas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Origen] [int] NOT NULL,
	[Destino] [int] NOT NULL,
	[Km] [float] NOT NULL,
	[Tiempo] [time](3) NOT NULL,
	[Precio] [money] NOT NULL,
 CONSTRAINT [PK_Rutas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Rutas]  WITH CHECK ADD  CONSTRAINT [FK_Rutas_Ciudades] FOREIGN KEY([Origen])
REFERENCES [dbo].[Ciudades] ([Id])
GO
ALTER TABLE [dbo].[Rutas] CHECK CONSTRAINT [FK_Rutas_Ciudades]
GO
ALTER TABLE [dbo].[Rutas]  WITH CHECK ADD  CONSTRAINT [FK_Rutas_Ciudades1] FOREIGN KEY([Destino])
REFERENCES [dbo].[Ciudades] ([Id])
GO
ALTER TABLE [dbo].[Rutas] CHECK CONSTRAINT [FK_Rutas_Ciudades1]
GO
/****** Object:  StoredProcedure [dbo].[usp_Dijkstra_KM]    Script Date: 30/04/2019 16:40:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Dijkstra_KM] (@StartNode int, @EndNode int = NULL)
AS
BEGIN
    -- Revertir automáticamente la transacción si algo sale mal.    
    SET NOCOUNT ON;
    -- Cree una tabla temporal para almacenar las estimaciones a medida que se ejecuta el algoritmo.
	CREATE TABLE #Nodes
	(
		Id int NOT NULL PRIMARY KEY,    -- El nodo Id
		Estimate decimal(10,0) NOT NULL,    -- ¿Cuál es la distancia al nodo hasta ahora?
		Predecessor int NULL,    -- Nodo anterior
		Done bit NOT NULL        -- ¿Distancia final?
	)

    -- Rellena la tabla temporal con los datos iniciales.
    INSERT INTO #Nodes (Id, Estimate, Predecessor, Done)
    SELECT Id, 9999999.999, NULL, 0 FROM dbo.Ciudades
    
    -- Establecemos la estimación a 0 en el nodo en el que comenzamos
    UPDATE #Nodes SET Estimate = 0 WHERE Id = @StartNode
    IF @@rowcount <> 1
    BEGIN
        DROP TABLE #Nodes
        RAISERROR ('Could not set start node', 11, 1) 
        ROLLBACK TRAN        
        RETURN 1
    END

    DECLARE @Origen int, @CurrentEstimate int

    -- Ejecutar el algoritmo.
    WHILE 1 = 1
    BEGIN
        -- Restablecer la variable, para que podamos detectar que no hay registros en el siguiente paso.
        SELECT @Origen = NULL

        -- Seleccione Id y la estimación actual para un nodo por el cual aún no se ha pasado.
        SELECT TOP 1 @Origen = Id, @CurrentEstimate = Estimate
        FROM #Nodes WHERE Done = 0 AND Estimate < 9999999.999
        ORDER BY Estimate
        
        -- Detenerse si no hay mas nodos accesibles, no visitados.
        IF @Origen IS NULL OR @Origen = @EndNode BREAK

        -- Ahora hemos terminado con este nodo
        UPDATE #Nodes SET Done = 1 WHERE Id = @Origen

        -- Actualice las estimaciones a todos los nodos vecinos de este 
		--(todos los nodos a los que hay Ciudades desde este nodo). 
		--Solo actualice la estimación si la nueva propuesta (para ir a través del nodo actual) es mejor (más baja).
        UPDATE #Nodes
		SET Estimate = @CurrentEstimate + e.Km, Predecessor = @Origen
        FROM #Nodes n INNER JOIN dbo.Rutas e ON n.Id = e.Destino
        WHERE Done = 0 AND e.Origen = @Origen AND (@CurrentEstimate + e.Km) < n.Estimate
        
    END;
    
	-- Seleccione los resultados. Utilizamos una expresión de tabla común 
	-- recursiva para obtener la ruta completa desde el nodo de inicio al nodo actual.
	WITH BacktraceCTE(Id, Nombre, Distancia, Nodos, Camino)
	AS
	(
		-- Esto selecciona el nodo inicial.
		SELECT n.Id, node.NombreCiudad, n.Estimate, CAST(n.Id AS varchar(8000)),
			CAST(node.NombreCiudad AS varchar(8000))
		FROM #Nodes n JOIN dbo.Ciudades node ON n.Id = node.Id
		WHERE n.Id = @StartNode
		
		UNION ALL
		
		-- Miembro recursivo, seleccione todos los nodos que tengan el anterior como su antecesor.
		SELECT n.Id, node.NombreCiudad, n.Estimate,
			CAST(cte.Nodos + ',' + CAST(n.Id as varchar(10)) as varchar(8000)),
			CAST(cte.Camino + ',' + node.NombreCiudad AS varchar(8000))
		FROM #Nodes n JOIN BacktraceCTE cte ON n.Predecessor = cte.Id
		JOIN dbo.Ciudades node ON n.Id = node.Id
	)
	SELECT * FROM BacktraceCTE
	WHERE Id = @EndNode OR @EndNode IS NULL 
	ORDER BY Id								
END    
GO
/****** Object:  StoredProcedure [dbo].[usp_Dijkstra_Precio]    Script Date: 30/04/2019 16:40:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Dijkstra_Precio] (@StartNode int, @EndNode int = NULL)
AS
BEGIN   
    SET XACT_ABORT ON    
    BEGIN TRAN
    
    SET NOCOUNT ON;

	CREATE TABLE #Nodes
	(
		Id int NOT NULL PRIMARY KEY,    
		Estimate decimal(10,0) NOT NULL,   
		Predecessor int NULL,   
		Done bit NOT NULL  
	)

    INSERT INTO #Nodes (Id, Estimate, Predecessor, Done)
    SELECT Id, 9999999.999, NULL, 0 FROM dbo.Ciudades
    
    UPDATE #Nodes SET Estimate = 0 WHERE Id = @StartNode
    IF @@rowcount <> 1
    BEGIN
        DROP TABLE #Nodes
        RAISERROR ('Could not set start node', 11, 1) 
        ROLLBACK TRAN        
        RETURN 1
    END

    DECLARE @Origen int, @CurrentEstimate int

    WHILE 1 = 1
    BEGIN
        SELECT @Origen = NULL

        SELECT TOP 1 @Origen = Id, @CurrentEstimate = Estimate
        FROM #Nodes WHERE Done = 0 AND Estimate < 9999999.999
        ORDER BY Estimate
        
        IF @Origen IS NULL OR @Origen = @EndNode BREAK

        UPDATE #Nodes SET Done = 1 WHERE Id = @Origen

        UPDATE #Nodes
		SET Estimate = @CurrentEstimate + e.Precio, Predecessor = @Origen
        FROM #Nodes n INNER JOIN dbo.Rutas e ON n.Id = e.Destino
        WHERE Done = 0 AND e.Origen = @Origen AND (@CurrentEstimate + e.Precio) < n.Estimate
        
    END;
    
	WITH BacktraceCTE(Id, Nombre, Precio, Nodos, Camino)
	AS
	(
		SELECT n.Id, node.NombreCiudad, n.Estimate, CAST(n.Id AS varchar(8000)),
			CAST(node.NombreCiudad AS varchar(8000))
		FROM #Nodes n JOIN dbo.Ciudades node ON n.Id = node.Id
		WHERE n.Id = @StartNode
		
		UNION ALL
		
		SELECT n.Id, node.NombreCiudad, n.Estimate,
			CAST(cte.Nodos + ',' + CAST(n.Id as varchar(10)) as varchar(8000)),
			CAST(cte.Camino + ',' + node.NombreCiudad AS varchar(8000))
		FROM #Nodes n JOIN BacktraceCTE cte ON n.Predecessor = cte.Id
		JOIN dbo.Ciudades node ON n.Id = node.Id
	)
	SELECT Id, Nombre, Precio, Nodos, Camino FROM BacktraceCTE
	WHERE Id = @EndNode OR @EndNode IS NULL 
	ORDER BY Id								
    
    DROP TABLE #Nodes
    COMMIT TRAN
    RETURN 0
END    
GO
/****** Object:  StoredProcedure [dbo].[usp_Dijkstra_Tiempo]    Script Date: 30/04/2019 16:40:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Dijkstra_Tiempo] (@StartNode int, @EndNode int = NULL)
AS
BEGIN   
    SET XACT_ABORT ON    
    BEGIN TRAN
    
    SET NOCOUNT ON;

	CREATE TABLE #Nodes
	(
		Id int NOT NULL PRIMARY KEY,   
		Estimate decimal(10,0) NOT NULL,  
		Predecessor int NULL,   
		Done bit NOT NULL     
	)

    INSERT INTO #Nodes (Id, Estimate, Predecessor, Done)
    SELECT Id, 9999999.999, NULL, 0 FROM dbo.Ciudades
    
    UPDATE #Nodes SET Estimate = 0 WHERE Id = @StartNode
    IF @@rowcount <> 1
    BEGIN
        DROP TABLE #Nodes
        RAISERROR ('Could not set start node', 11, 1) 
        ROLLBACK TRAN        
        RETURN 1
    END

    DECLARE @Origen int, @CurrentEstimate int

    WHILE 1 = 1
    BEGIN
        SELECT @Origen = NULL

        SELECT TOP 1 @Origen = Id, @CurrentEstimate = Estimate
        FROM #Nodes WHERE Done = 0 AND Estimate < 9999999.999
        ORDER BY Estimate
        
        IF @Origen IS NULL OR @Origen = @EndNode BREAK

        UPDATE #Nodes SET Done = 1 WHERE Id = @Origen

        UPDATE #Nodes
		SET Estimate = @CurrentEstimate + DATEDIFF(MINUTE, 0, e.Tiempo), Predecessor = @Origen
        FROM #Nodes n INNER JOIN dbo.Rutas e ON n.Id = e.Destino
        WHERE Done = 0 AND e.Origen = @Origen AND (@CurrentEstimate +  DATEDIFF(MINUTE, 0, e.Tiempo)) < n.Estimate
        
    END;
    
	WITH BacktraceCTE(Id, Nombre, Tiempo, Nodos, Camino)
	AS
	(
		SELECT n.Id, node.NombreCiudad, n.Estimate, CAST(n.Id AS varchar(8000)),
			CAST(node.NombreCiudad AS varchar(8000))
		FROM #Nodes n JOIN dbo.Ciudades node ON n.Id = node.Id
		WHERE n.Id = @StartNode
		
		UNION ALL
		
		SELECT n.Id, node.NombreCiudad, n.Estimate,
			CAST(cte.Nodos + ',' + CAST(n.Id as varchar(10)) as varchar(8000)),
			CAST(cte.Camino + ',' + node.NombreCiudad AS varchar(8000))
		FROM #Nodes n JOIN BacktraceCTE cte ON n.Predecessor = cte.Id
		JOIN dbo.Ciudades node ON n.Id = node.Id
	)
	SELECT Id, Nombre, Tiempo, Nodos, Camino FROM BacktraceCTE
	WHERE Id = @EndNode OR @EndNode IS NULL
	ORDER BY Id								
    
    DROP TABLE #Nodes
    COMMIT TRAN
    RETURN 0
END    
GO

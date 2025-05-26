-- Phones Table
CREATE TABLE [dbo].[Phones] (
    [id]              INT           NOT NULL,
    [name]            VARCHAR(50)   NOT NULL,
    [brand]           VARCHAR(50)   NOT NULL,
    [model]           VARCHAR(50)   NOT NULL,
    [color]           VARCHAR(50)   NOT NULL,
    [price]           FLOAT(53)     NOT NULL,
    [description]     VARCHAR(MAX)  NULL,
    [quantity]        INT           NOT NULL,
    [imagePath]       VARCHAR(255)  NOT NULL,
    [QRCode]          VARCHAR(100)  NOT NULL,
    [operatingSystem] VARCHAR(50)   NULL,
    [screenSize]      FLOAT(53)     NOT NULL,
    [storageCapacity] INT           NOT NULL,
    [ramSize]         INT           NOT NULL,
    [cameraQuality]   INT           NOT NULL,
    [cpuType]         VARCHAR(50)   NULL,
    [batteryCapacity] INT           NOT NULL,
    [tablet]          BIT           NOT NULL,

    CONSTRAINT [PK_Phones] PRIMARY KEY CLUSTERED ([id]),
    CONSTRAINT [UQ_Phones_Name] UNIQUE ([name]),
    CONSTRAINT [UQ_Phones_ImagePath] UNIQUE ([imagePath]),
    CONSTRAINT [UQ_Phones_QRCode] UNIQUE ([QRCode])
);

-- Folds Table
CREATE TABLE [dbo].[Folds] (
    [id]                INT           NOT NULL,
    [name]              VARCHAR(50)   NOT NULL,
    [brand]             VARCHAR(50)   NOT NULL,
    [model]             VARCHAR(50)   NOT NULL,
    [color]             VARCHAR(50)   NOT NULL,
    [price]             FLOAT(53)     NOT NULL,
    [description]       VARCHAR(MAX)  NULL,
    [quantity]          INT           NOT NULL,
    [imagePath]         VARCHAR(255)  NOT NULL,
    [QRCode]            VARCHAR(100)  NOT NULL,
    [operatingSystem]   VARCHAR(50)   NULL,
    [screenSize]        FLOAT(53)     NOT NULL,
    [storageCapacity]   INT           NOT NULL,
    [ramSize]           INT           NOT NULL,
    [cameraQuality]     INT           NOT NULL,
    [cpuType]           VARCHAR(50)   NULL,
    [batteryCapacity]   INT           NOT NULL,
    [tablet]            BIT           NOT NULL,
    [foldType]          VARCHAR(50)   NOT NULL,
    [hingeMaterial]     VARCHAR(50)   NOT NULL,
    [displayType]       VARCHAR(50)   NOT NULL,
    [durabilityRating]  VARCHAR(50)   NOT NULL,
    [sizeOfOpenedScreen] FLOAT(53)    NOT NULL,

    CONSTRAINT [PK_Folds] PRIMARY KEY CLUSTERED ([id]),
    CONSTRAINT [UQ_Folds_Name] UNIQUE ([name]),
    CONSTRAINT [UQ_Folds_ImagePath] UNIQUE ([imagePath]),
    CONSTRAINT [UQ_Folds_QRCode] UNIQUE ([QRCode])
);

-- Laptops Table
CREATE TABLE [dbo].[Laptops] (
    [id]              INT           NOT NULL,
    [name]            VARCHAR(50)   NOT NULL,
    [brand]           VARCHAR(50)   NOT NULL,
    [model]           VARCHAR(50)   NOT NULL,
    [color]           VARCHAR(50)   NOT NULL,
    [price]           FLOAT(53)     NOT NULL,
    [description]     VARCHAR(MAX)  NULL,
    [quantity]        INT           NOT NULL,
    [imagePath]       VARCHAR(255)  NOT NULL,
    [QRCode]          VARCHAR(100)  NOT NULL,
    [operatingSystem] VARCHAR(50)   NOT NULL,
    [storageCapacity] INT           NOT NULL,
    [ramSize]         INT           NOT NULL,
    [graphicsCard]    VARCHAR(50)   NOT NULL,
    [cpuType]         VARCHAR(50)   NOT NULL,
    [screenSize]      FLOAT(53)     NOT NULL,
    [batteryLife]     VARCHAR(50)   NOT NULL,

    CONSTRAINT [PK_Laptops] PRIMARY KEY CLUSTERED ([id]),
    CONSTRAINT [UQ_Laptops_Name] UNIQUE ([name]),
    CONSTRAINT [UQ_Laptops_ImagePath] UNIQUE ([imagePath]),
    CONSTRAINT [UQ_Laptops_QRCode] UNIQUE ([QRCode])
);

-- GammingLaptops Table
CREATE TABLE [dbo].[GammingLaptops] (
    [id]              INT           NOT NULL,
    [name]            VARCHAR(50)   NOT NULL,
    [brand]           VARCHAR(50)   NOT NULL,
    [model]           VARCHAR(50)   NOT NULL,
    [color]           VARCHAR(50)   NOT NULL,
    [price]           FLOAT(53)     NOT NULL,
    [description]     VARCHAR(MAX)  NULL,
    [quantity]        INT           NOT NULL,
    [imagePath]       VARCHAR(255)  NOT NULL,
    [QRCode]          VARCHAR(100)  NOT NULL,
    [operatingSystem] VARCHAR(50)   NOT NULL,
    [storageCapacity] INT           NOT NULL,
    [ramSize]         INT           NOT NULL,
    [graphicsCard]    VARCHAR(50)   NOT NULL,
    [cpuType]         VARCHAR(50)   NOT NULL,
    [screenSize]      FLOAT(53)     NOT NULL,
    [batteryLife]     VARCHAR(50)   NOT NULL,
    [coolingSystem]   VARCHAR(50)   NOT NULL,
    [keyboardType]    VARCHAR(50)   NOT NULL,
    [frameRate]       INT           NOT NULL,

    CONSTRAINT [PK_GammingLaptops] PRIMARY KEY CLUSTERED ([id]),
    CONSTRAINT [UQ_GammingLaptops_Name] UNIQUE ([name]),
    CONSTRAINT [UQ_GammingLaptops_ImagePath] UNIQUE ([imagePath]),
    CONSTRAINT [UQ_GammingLaptops_QRCode] UNIQUE ([QRCode])
);

-- TwoInOnes Table
CREATE TABLE [dbo].[TwoInOnes] (
    [id]                 INT           NOT NULL,
    [name]               VARCHAR(50)   NOT NULL,
    [brand]              VARCHAR(50)   NOT NULL,
    [model]              VARCHAR(50)   NOT NULL,
    [color]              VARCHAR(50)   NOT NULL,
    [price]              FLOAT(53)     NOT NULL,
    [description]        VARCHAR(MAX)  NULL,
    [quantity]           INT           NOT NULL,
    [imagePath]          VARCHAR(255)  NOT NULL,
    [QRCode]             VARCHAR(100)  NOT NULL,
    [operatingSystem]    VARCHAR(50)   NOT NULL,
    [storageCapacity]    INT           NOT NULL,
    [ramSize]            INT           NOT NULL,
    [graphicsCard]       VARCHAR(50)   NOT NULL,
    [cpuType]            VARCHAR(50)   NOT NULL,
    [screenSize]         FLOAT(53)     NOT NULL,
    [batteryLife]        VARCHAR(50)   NOT NULL,
    [detachableKeyboard] BIT           NOT NULL,
    [hingeType]          VARCHAR(50)   NOT NULL,

    CONSTRAINT [PK_TwoInOnes] PRIMARY KEY CLUSTERED ([id]),
    CONSTRAINT [UQ_TwoInOnes_Name] UNIQUE ([name]),
    CONSTRAINT [UQ_TwoInOnes_ImagePath] UNIQUE ([imagePath]),
    CONSTRAINT [UQ_TwoInOnes_QRCode] UNIQUE ([QRCode])
);

-- Cpus Table
CREATE TABLE [dbo].[Cpus] (
    [id]           INT           NOT NULL,
    [name]         VARCHAR(50)   NOT NULL,
    [brand]        VARCHAR(50)   NOT NULL,
    [model]        VARCHAR(50)   NOT NULL,
    [color]        VARCHAR(50)   NOT NULL,
    [price]        FLOAT(53)     NOT NULL,
    [description]  VARCHAR(MAX)  NULL,
    [quantity]     INT           NOT NULL,
    [imagePath]    VARCHAR(255)  NOT NULL,
    [QRCode]       VARCHAR(100)  NOT NULL,
    [cores]        INT           NOT NULL,
    [frequencyGHz] FLOAT(53)     NOT NULL,
    [socketType]   VARCHAR(50)   NOT NULL,

    CONSTRAINT [PK_Cpus] PRIMARY KEY CLUSTERED ([id]),
    CONSTRAINT [UQ_Cpus_Name] UNIQUE ([name]),
    CONSTRAINT [UQ_Cpus_ImagePath] UNIQUE ([imagePath]),
    CONSTRAINT [UQ_Cpus_QRCode] UNIQUE ([QRCode])
);

-- Gpus Table
CREATE TABLE [dbo].[Gpus] (
    [id]          INT           NOT NULL,
    [name]        VARCHAR(50)   NOT NULL,
    [brand]       VARCHAR(50)   NOT NULL,
    [model]       VARCHAR(50)   NOT NULL,
    [color]       VARCHAR(50)   NOT NULL,
    [price]       FLOAT(53)     NOT NULL,
    [description] VARCHAR(MAX)  NULL,
    [quantity]    INT           NOT NULL,
    [imagePath]   VARCHAR(255)  NOT NULL,
    [QRCode]      VARCHAR(100)  NOT NULL,
    [memoryGB]    INT           NOT NULL,
    [chipset]     VARCHAR(50)   NOT NULL,

    CONSTRAINT [PK_Gpus] PRIMARY KEY CLUSTERED ([id]),
    CONSTRAINT [UQ_Gpus_Name] UNIQUE ([name]),
    CONSTRAINT [UQ_Gpus_ImagePath] UNIQUE ([imagePath]),
    CONSTRAINT [UQ_Gpus_QRCode] UNIQUE ([QRCode])
);

/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2012                    */
/* Created on:     20/07/2023 13:36:03                          */
/*==============================================================*/





if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Emprestimo') and o.name = 'FK_Emprestimo_Pessoa')
alter table Emprestimo
   drop constraint FK_Emprestimo_REFERENCE_Pessoa
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Emprestimo') and o.name = 'FK_Emprestimo_Jogos')
alter table Emprestimo
   drop constraint FK_Emprestimo_REFERENCE_Jogos
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Pessoa')
            and   type = 'U')
   drop table Pessoa
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Emprestimo')
            and   type = 'U')
   drop table Emprestimo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Jogos')
            and   type = 'U')
   drop table Jogos
go

/*==============================================================*/
/* Table: Pessoa                                        */
/*==============================================================*/
create table Pessoa (
   idPessoa        int                  identity,
   nome            varchar(100)         not null,
   constraint PK_Pessoa primary key nonclustered (idPessoa)
)
go

/*==============================================================*/
/* Table: Emprestimo                                        */
/*==============================================================*/
create table Emprestimo (
   idEmprestimo int                  identity,
   idPessoa            int                  null,
   idJogo              int                  null,
   dtRetirada          datetime             null,
   dtEntrega           datetime             null,
   constraint PK_Emprestimo primary key nonclustered (idEmprestimo)
)
go

/*==============================================================*/
/* Table: Jogos                                              */
/*==============================================================*/
create table Jogos (
   idJogo              int                  identity,
   descricao           varchar(100)         not null,
   flDisponivel        bit                  null,
   constraint PK_Jogos primary key nonclustered (idJogo)
)
go

alter table Emprestimo
   add constraint FK_Emprestimo_REFERENCE_Pessoa foreign key (idPessoa)
      references Pessoa (idPessoa)
go

alter table Emprestimo
   add constraint FK_Emprestimo_REFERENCE_Jogos foreign key (idJogo)
      references Jogos (idJogo)
go
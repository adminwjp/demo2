
    PRAGMA foreign_keys = OFF

    drop table if exists t_database

    drop table if exists t_table

    drop table if exists t_column

    PRAGMA foreign_keys = ON

    create table t_database (
        id INTEGER not null,
       name TEXT,
       program_name TEXT,
       remark TEXT,
       primary key (id)
    )

    create table t_table (
        id INTEGER not null,
       class_name TEXT,
       table_name TEXT,
       remark TEXT,
       title TEXT,
       database_id INTEGER,
       primary key (id),
       constraint fk_database_id foreign key (database_id) references t_database
    )

    create table t_column (
        id INTEGER not null,
       cloum_name TEXT,
       property_name TEXT,
       remark TEXT,
       csharep_property_type TEXT,
       title TEXT,
       table_id INTEGER,
       primary key (id),
       constraint fk_table_id foreign key (table_id) references t_table
    )

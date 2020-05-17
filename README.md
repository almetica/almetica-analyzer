# almetica-analyzer

Simple fork of the analyzer code by Mirrawrs. Used to extract data needed by
Almetica to serve as a custom server implementation for the MMORPG Tera.

## Build

Visual Studio 2019 (CE compatible)

## Run

```cmd
TeraAnalyse.exe PATH_TO_TERA_EXE
```

The program will output three files:
 - keys.yaml
 - opcode.yaml
 - messages.yaml

You might need to retry to start the programm several times until it extracts
the files successfully. You also most likely need to cleanup the opcode.yaml
so that you only have the opcodes with the prefix "S_" and "C_".

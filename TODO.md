# TODO Repo

## Fix

- [ ] [Modificar la estructura de ejecución](#modificar-la-estructura-de-ejecución)
- [ ] [Si ya existe un entorno virtual en la ruta, obtenerlo (el nombre)](#si-ya-existe-un-entorno-virtual-en-la-ruta-obtenerlo-el-nombre)
- [ ] [Mejorar el manejo de Errores/Excepciones](#mejorar-el-manejo-de-erroresexcepciones)
- [ ] [Error en requirements.txt](#error-en-requirementstxt-añadido-después-de-crear-el-entorno-virtual)

## Features

- [ ] [Añadir soporte para Linux](#añadir-soporte-para-linux)
- [ ] [Añadir soporte para MacOS](#añadir-soporte-para-macos)

## Others

- [ ] [Mejorar mensajes de ejecución](#mejorar-mensajes-de-ejecución)

---

## Fix

### Modificar la estructura de ejecución

Cuando el programa es llamado desde la terminal, este siempre abre una nueva terminal, la idea es que la terminal (nueva) solo se haga apertura cuando se llama desde la URL del file explorer, cuando es llamado desde una consola, se debe ejecutar todo dentro de la misma consola!

### Si ya existe un entorno virtual en la ruta, obtenerlo (el nombre)

Al momento de activar el entorno virtual, se requiere el nombre de la "carpeta", usualmente se llama `.venv`, pero en algunas ocasiones esto puede diferir, por consiguiente a la hora de "activar" el entorno virtual SIEMPRE SE USA EL COMANDO `.venv\Scripts\activate` (En windows), por consiguiente si el nombre NO ES `.venv`, no se podrá continuar con el proceso.

### Mejorar el manejo de Errores/Excepciones

El manejo de errores está bastante "simple"/no robusto, si un comando arroja una excepción, la única acción que el programa toma, es imprimir el mensaje, y si es posible seguir. Pero no se tiene un sistema de Excepciones preciso.

### Error en requirements.txt (Añadido después de crear el entorno virtual)

Al ejecutarse en un directorio sin `requirements.txt`, el programa crea el entorno virtual sin errores. Si el usuario añade `requirements.txt` posteriormente (o si ya existe un `.venv`), el programa no está diseñado para instalar esos paquetes añadidos; en consecuencia, `pip check` no mostrará errores, porque nunca se ejecutó `pip install -r requirements.txt`.

## Features

### Añadir soporte para Linux

Actualmente el programa solo está escrito para Windows, hace falta añadir código para Linux.

### Añadir soporte para MacOS

Actualmente el programa solo está escrito para Windows, hace falta añadir código para MacOS.

## Others

### Mejorar mensajes de ejecución

Los mensajes de la consola, muchas veces no son claros (Aunque solo son mensajes de salida) se deben mejorar para mejor entendimiento y confianza para el usuario, por ejemplo, si obtengo este mensaje al ejecutar `where python` (en la [versión actual](https://github.com/Dev2Forge/Init-Venv/tree/b65595a70c2ab699d66840ae6999c5977c4fe0f4)):

```shell
INFO: Could not find files for the given pattern(s).
```

Un mejor mensaje sería:

```shell
Make sure you have Python installed on your system (Also have it in your PATH)
```


---

## Fix Linux Attempt

```bash
srm@debian-srm:/mnt/SRM/GITHUB/ORGs/Dev2Forge/repos/Init-Venv$ dotnet run /mnt/SRM/GITHUB/ORGs/Dev2Forge/tests/Init-Venv-Tests
---------
Init-Venv (C) 2025 - Dev2Forge
All Rights Reserved.
---------

[ INFO ] Try executing command: "cd /d /mnt/SRM/GITHUB/ORGs/Dev2Forge/tests/Init-Venv-Tests && which python3"
[ ERROR] QLayout: Cannot add a null widget to QHBoxLayout/

[ ERROR] QThreadStorage: Thread 0x558ca3ad4700 exited after QThreadStorage 9 destroyed
[ WARN ] Completed with errors (Exit Code: 0)
Errores: QLayout: Cannot add a null widget to QHBoxLayout/
QThreadStorage: Thread 0x558ca3ad4700 exited after QThreadStorage 9 destroyed

[ INFO ] Try executing command: "python3 -m venv .venv"
[ ERROR] konsole: Opción desconocida «m».
[ ERROR] QThreadStorage: Thread 0x56099d89f700 exited after QThreadStorage 9 destroyed
[ ERROR] QThreadStorage: Thread 0x56099d89f700 exited after QThreadStorage 5 destroyed
[ ERROR] QThreadStorage: Thread 0x56099d89f700 exited after QThreadStorage 4 destroyed
[ WARN ] Completed with errors (Exit Code: 1)
Errores: konsole: Opción desconocida «m».
QThreadStorage: Thread 0x56099d89f700 exited after QThreadStorage 9 destroyed
QThreadStorage: Thread 0x56099d89f700 exited after QThreadStorage 5 destroyed
QThreadStorage: Thread 0x56099d89f700 exited after QThreadStorage 4 destroyed

[ INFO ] Try executing command: "which pip3"
[ ERROR] QLayout: Cannot add a null widget to QHBoxLayout/
[ ERROR] QThreadStorage: Thread 0x56213d97a700 exited after QThreadStorage 9 destroyed
[ WARN ] Completed with errors (Exit Code: 0)
Errores: QLayout: Cannot add a null widget to QHBoxLayout/
QThreadStorage: Thread 0x56213d97a700 exited after QThreadStorage 9 destroyed

[ INFO ] Try executing command: "cd /d /mnt/SRM/GITHUB/ORGs/Dev2Forge/tests/Init-Venv-Tests && source .venv/in/activate && which python3"
[ ERROR] QLayout: Cannot add a null widget to QHBoxLayout/
[ ERROR] QThreadStorage: Thread 0x55de44df8700 exited after QThreadStorage 9 destroyed
[ WARN ] Completed with errors (Exit Code: 0)
Errores: QLayout: Cannot add a null widget to QHBoxLayout/
QThreadStorage: Thread 0x55de44df8700 exited after QThreadStorage 9 destroyed

Program exit Sucessfully!
Press ENTER to close...

```
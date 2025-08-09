# TODO Repo

## Fix

- [x] [¡Mejorar la validación de la ruta de Python!](#mejorar-validacion-ruta-python)
  - Realicé este punto, se requiere refactorizar (Redundancias)/funcional
- [x] [¡Mejorar la validación de la ruta de Pip!](#mejorar-validacion-ruta-pip)
  - Realicé este punto, se requiere refactorizar (Redundancias)/funcional
- [ ] [Si ya existe un entorno virtual en la ruta, obtenerlo (el nombre)](#existe-entorno-virtual-obtener-nombre)
- [ ] [Mejorar el manejo de Errores/Excepciones](#mejorar-manejo-errores-excepciones)
- [ ] [Error en requirements.txt](#error-requirements-added-after-venv)

## Features

- [ ] [Añadir soporte para Linux](#anadir-soporte-linux)
- [ ] [Añadir soporte para MacOS](#anadir-soporte-macos)

## Others

- [ ] [Mejorar mensajes de ejecución](#mejorar-mensajes-ejecucion)

---

## Fix

### ¡Mejorar la validación de la ruta de Python! {#mejorar-validacion-ruta-python}

Solo se verifica si python existe en el sistema, pero no se toma en cuenta después de creado el entorno virtual, se debe volver a validar, pero ¡verificando que realmente hay un "python.exe" en el entorno virtual actual!

### ¡Mejorar la validación de la ruta de Pip! {#mejorar-validacion-ruta-pip}

De la misma forma que se debe hacer con la ruta de Python.

### Si ya existe un entorno virtual en la ruta, obtenerlo (el nombre) {#existe-entorno-virtual-obtener-nombre}

Al momento de activar el entorno virtual, se requiere el nombre de la "carpeta", usualmente se llama `.venv`, pero en algunas ocasiones esto puede diferir, por consiguiente a la hora de "activar" el entorno virtual SIEMPRE SE USA EL COMANDO `.venv\Scripts\activate` (En windows), por consiguiente si el nombre NO ES `.venv`, no se podrá continuar con el proceso.

### Mejorar el manejo de Errores/Excepciones {#mejorar-manejo-errores-excepciones}

El manejo de errores está bastante "simple"/no robusto, si un comando arroja una excepción, la única acción que el programa toma, es imprimir el mensaje, y si es posible seguir. Pero no se tiene un sistema de Excepciones preciso.

### Error en requirements.txt {#error-requirements-added-after-venv}

Al ejecutarse en un directorio sin `requirements.txt`, el programa crea el entorno virtual sin errores. Si el usuario añade `requirements.txt` posteriormente (o si ya existe un `.venv`), el programa no está diseñado para instalar esos paquetes añadidos; en consecuencia, `pip check` no mostrará errores, porque nunca se ejecutó `pip install -r requirements.txt`.

## Features

### Añadir soporte para Linux {#anadir-soporte-linux}

Actualmente el programa solo está escrito para Windows, hace falta añadir código para Linux.

### Añadir soporte para MacOS {#anadir-soporte-macos}

Actualmente el programa solo está escrito para Windows, hace falta añadir código para MacOS.

## Others

### Mejorar mensajes de ejecución {#mejorar-mensajes-ejecucion}

Los mensajes de la consola, muchas veces no son claros (Aunque solo son mensajes de salida) se deben mejorar para mejor entendimiento y confianza para el usuario, por ejemplo, si obtengo este mensaje al ejecutar `where python` (en la [versión actual](https://github.com/Dev2Forge/Init-Venv/tree/b65595a70c2ab699d66840ae6999c5977c4fe0f4)):

```shell
INFO: Could not find files for the given pattern(s).
```

Un mejor mensaje sería:

```shell
Make sure you have Python installed on your system (Also have it in your PATH)
```

# TODO Repo

## Fix

- [x] [¡Mejorar la validación de la ruta de Python!](#mejorar-la-validación-de-la-ruta-de-python)
  - Realicé este punto, se requiere refactorizar (Redundancias)/funcional
- [x] [¡Mejorar la validación de la ruta de Pip!](#mejorar-la-validación-de-la-ruta-de-pip)
  - Realicé este punto, se requiere refactorizar (Redundancias)/funcional
- [ ] [Si ya existe un entorno virtual en la ruta, obtenerlo (el nombre)](#si-ya-existe-un-entorno-virtual-en-la-ruta-obtenerlo-el-nombre)
- [ ] [Mejorar el manejo de Errores/Excepciones](#mejorar-el-manejo-de-erroresexcepciones)

## Features

- [ ] [Añadir soporte para Linux](#añadir-soporte-para-linux)
- [ ] [Añadir soporte para MacOS](#añadir-soporte-para-macos)

---

## ¡Mejorar la validación de la ruta de Python!

Solo se verifica si python existe en el sistema, pero no se toma en cuenta después de creado el entorno virtual, se debe volver a validar, pero ¡verificando que realmente hay un "python.exe" en el entorno virtual actual!

## ¡Mejorar la validación de la ruta de Pip!

De la misma forma que se debe hacer con la ruta de Python.

## Si ya existe un entorno virtual en la ruta, obtenerlo (el nombre)

Al momento de activar el entorno virtual, se requiere el nombre de la "carpeta", usualmente se llama `.venv`, pero en algunas ocasiones esto puede diferir, por consiguiente a la hora de "activar" el entorno virtual SIEMPRE SE USA EL COMANDO `.venv\Scripts\activate` (En windows), por consiguiente si el nombre NO ES `.venv`, no se podrá continuar con el proceso.

## Mejorar el manejo de Errores/Excepciones

El manejo de errores está bastante "simple"/no robusto, si un comando arroja una excepción, la única acción que el programa toma, es imprimir el mensaje, y si es posible seguir. Pero no se tiene un sistema de Excepciones preciso.

## Añadir soporte para Linux

Actualmente el programa solo está escrito para Windows, hace falta añadir código para Linux.

## Añadir soporte para MacOS

Actualmente el programa solo está escrito para Windows, hace falta añadir código para MacOS.
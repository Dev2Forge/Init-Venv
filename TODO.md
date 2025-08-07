# TODO Repo:

## Fix

<!-- Python Paths -->
<details>
<summary>¡Mejorar la validación de la ruta de Python!</summary>
<p>Actualmente, solo se verifica si python existe en el sistema, pero no se toma en cuenta después de creado el entorno virtual, se debe volver a validar, pero ¡verificando que realmente hay un "python.exe" en el entorno virtual actual!</p>
</details>

<!-- Pip Paths -->
<details>
<summary>¡Mejorar la validación de la ruta de Pip!</summary>
<p>De la misma forma que se debe hacer con la ruta de Pyhon.</p>
</details>

<!-- Venv name -->
<details>
<summary>Si ya existe un entorno virtual en la ruta, obtenerlo (el nombre)</summary>
<p>Al momento de activar el entorno virtual, se requiere el nombre de la "carpeta", usualmente se llama <code>.venv</code>, pero en algunas ocasiones esto puede diferir, por consiguiente a la hora de "activar" el entorno virtual SIEMPRE SE USA EL COMANDO <code>.venv\Scripts\activate</code> (En windows), por consiguiente si el nombre NO ES <code>.venv</code>, no se podrá continuar con el proceso</p>
</details>

<!-- Process Exceptions -->
<details>
<summary>Mejorar el manejo de Errores/Excepciones</summary>
<p>El manejo de errores está bastante "simple"/no robusto, si un comando arroja una excepción, la única acción que el programa toma, es imprimir el mensaje, y si es posible seguir. Pero no se tiene un sistema de Excepciones preciso.</p>
</details>

## Features

<!-- Support Linux -->
<details>
<summary>Añadir soporte para Linux</summary>
<p>Actualmente el programa solo está escrito para Windows, hace falta añadir código para Linux</p>
</details>

<!-- Support MacOS -->
<details>
<summary>Añadir soporte para MacOS</summary>
<p>Actualmente el programa solo está escrito para Windows, hace falta añadir código para MacOS</p>
</details>
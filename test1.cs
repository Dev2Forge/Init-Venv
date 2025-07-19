// Init‑Venv — Initialize a virtual environment automatically.
// Copyright (C) 2025 Dev2Forge
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

using InitVenv.src.App.Utils;

namespace InitVenv
{
    class App1
    {

        public static void FileTest(string pathArg)
        {
            string __fullPath = Paths.ToUniversalPaths(Path.GetFullPath(pathArg));
            Console.WriteLine(string.Format("{0}", __fullPath));
        }
    }
}
/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2022, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Structure.MaterialFragments;
using BH.oM.Structure.SurfaceProperties;
using BH.oM.Physical;
using rf = Dlubal.RFEM5;

namespace BH.Adapter.RFEM
{
    public partial class RFEMAdapter
    {

        /***************************************************/
        /**** Private methods                           ****/
        /***************************************************/

        private bool CreateCollection(IEnumerable<ISurfaceProperty> surfaceProperties)
        {
            /*
            if (surfaceProperties.Count() > 0)
            {
                
                int idNum = 0;
                int matNumId = 0;
                List<ISurfaceProperty> srfPropList = surfaceProperties.ToList();
                rf.SurfaceStiffness[] srfStiffness = new rf.SurfaceStiffness[srfPropList.Count()]; // TODO: this is likely not the right type

                for (int i = 0; i < srfPropList.Count(); i++)
                {

                    idNum = System.Convert.ToInt32(srfPropList[i].CustomData[AdapterIdName]);// NextId(secList[i].GetType()));
                    matNumId = System.Convert.ToInt32(srfPropList[i].Material.CustomData[AdapterIdName]);

                    srfStiffness[i] = srfPropList[i].ToRFEM();
                    
                    //modelData.SetSurfaceStiffness(srfStiffness[i]); <--- such a method does not exist !!!
                }

            }
            */
            return true;
        }


        /***************************************************/
    }
}



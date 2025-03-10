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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Structure.MaterialFragments;
using rf = Dlubal.RFEM5;


namespace BH.Adapter.RFEM
{
    public partial class RFEMAdapter
    {

        /***************************************************/
        /**** Private methods                           ****/
        /***************************************************/


        private List<IMaterialFragment> ReadMaterials(List<string> ids = null)
        {
            m_materialDict.Clear();
            List<IMaterialFragment> materialList = new List<IMaterialFragment>();

            if (ids == null)
            {
                foreach (rf.Material rfMaterial in modelData.GetMaterials())
                {
                    IMaterialFragment material = rfMaterial.FromRFEM();
                    materialList.Add(material);

                    int matId = rfMaterial.No;// get proper conversion from the 'material.TextID'
                    if (!m_materialDict.ContainsKey(matId))
                    {
                        m_materialDict.Add(matId, material);
                    }
                }
            }
            else
            {
                foreach (string id in ids)
                {
                    materialList.Add(modelData.GetMaterial(Int32.Parse(id), rf.ItemAt.AtNo).GetData().FromRFEM());
                }
            }


            return materialList;
        }

        /***************************************************/

    }
}



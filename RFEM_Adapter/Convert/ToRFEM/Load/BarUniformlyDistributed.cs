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
using BH.oM.Physical.Materials;
using BH.oM.Structure.Elements;
using BH.oM.Structure.Loads;
using BH.oM.Structure.SectionProperties;
using BH.Engine.Adapter;
using BH.Engine.Geometry;
using BH.oM.Adapters.RFEM;
using rf = Dlubal.RFEM5;

namespace BH.Adapter.RFEM
{
    public static partial class Convert
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static List<rf.MemberLoad> ToRFEM(this BarUniformlyDistributedLoad load, int loadId, int loadcaseId)
        {
            List<rf.MemberLoad> rfLoadList = new List<rf.MemberLoad>();

            rf.MemberLoad rfLoad = new rf.MemberLoad();
            rfLoad.Distribution = rf.LoadDistributionType.UniformType;
            rfLoad.RelativeDistances = false;
            rfLoad.ReferenceTo = rf.MemberLoadReferenceType.MembersType;

            List<string> objectIds = load.Objects.Elements.Select(x => x.AdapterId<int>(typeof(RFEMId)).ToString()).ToList();
            string objectIdString = string.Join(",", objectIds);
            rfLoad.ObjectList = objectIdString;

            rfLoad.IsValid = true;
            rfLoad.Comment = "";
            rfLoad.ID = "";
            rfLoad.Tag = "";

            if(load.Force.Length() == 0 & load.Moment.Length() == 0)
            {
                Engine.Base.Compute.RecordWarning("Zero forces set. No load pushed!");
                return rfLoadList;
            }

            if(load.Force.Length() != 0)
            {
                rfLoad.Type = rf.LoadType.ForceType;
                if(load.Force.X!=0)
                {
                    rfLoad.No = loadId;
                    rf.MemberLoad xLoad = rfLoad;
                    xLoad.Direction = load.Axis == LoadAxis.Global ? rf.LoadDirectionType.GlobalXType : rf.LoadDirectionType.LocalXType;
                    xLoad.Magnitude1 = load.Force.X;
                    rfLoadList.Add(xLoad);
                    loadId++;
                }

                if (load.Force.Y != 0)
                {
                    rfLoad.No = loadId;
                    rf.MemberLoad yLoad = rfLoad;
                    yLoad.Direction = load.Axis == LoadAxis.Global ? rf.LoadDirectionType.GlobalYType : rf.LoadDirectionType.LocalYType;
                    yLoad.Magnitude1 = load.Force.Y;
                    rfLoadList.Add(yLoad);
                    loadId++;
                }

                if (load.Force.Z != 0)
                {
                    rfLoad.No = loadId;
                    rf.MemberLoad zLoad = rfLoad;
                    zLoad.Direction = load.Axis == LoadAxis.Global ? rf.LoadDirectionType.GlobalZType : rf.LoadDirectionType.LocalZType;
                    zLoad.Magnitude1 = load.Force.Z;
                    rfLoadList.Add(zLoad);
                    loadId++;
                }
            }

            if (load.Moment.Length() != 0)
            {
                rfLoad.Type = rf.LoadType.MomentType;
                if (load.Moment.X != 0)
                {
                    rfLoad.No = loadId;
                    rf.MemberLoad uxLoad = rfLoad;
                    uxLoad.Direction = load.Axis == LoadAxis.Global ? rf.LoadDirectionType.GlobalXType : rf.LoadDirectionType.LocalXType;
                    uxLoad.Magnitude1 = load.Moment.X;
                    rfLoadList.Add(uxLoad);
                    loadId++;
                }

                if (load.Moment.Y != 0)
                {
                    rfLoad.No = loadId;
                    rf.MemberLoad uyLoad = rfLoad;
                    uyLoad.Direction = load.Axis == LoadAxis.Global ? rf.LoadDirectionType.GlobalXType : rf.LoadDirectionType.LocalXType;
                    uyLoad.Magnitude1 = load.Moment.X;
                    rfLoadList.Add(uyLoad);
                    loadId++;
                }

                if (load.Moment.X != 0)
                {
                    rfLoad.No = loadId;
                    rf.MemberLoad uzLoad = rfLoad;
                    uzLoad.Direction = load.Axis == LoadAxis.Global ? rf.LoadDirectionType.GlobalXType : rf.LoadDirectionType.LocalXType;
                    uzLoad.Magnitude1 = load.Moment.X;
                    rfLoadList.Add(uzLoad);
                    loadId++;
                }
            }


            return rfLoadList;
        }
    }
}

/*
   Copyright 2011 Microsoft Corp.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.

*/

/*******************************************************************************
 *  AWS SDK for WP7
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Amazon.S3.Model
{
    /// <summary>
    /// IComparable class that is used when sorting a lit of grants.
    /// </summary>
    public class ComparatorGrant : IComparer<S3Grant>
    {
        /// <summary>
        /// Compares the string representation of the grants
        /// </summary>
        public int Compare(S3Grant x, S3Grant y)
        {
            return string.Compare(x.ToString(), y.ToString(), StringComparison.OrdinalIgnoreCase);
            //return x.ToString().CompareTo(y.ToString());
        }
    }

    /// <summary>
    /// Represents a grant for an bucket/object ACL. A grant contains
    /// a S3Grantee and a S3Permission for that S3Grantee.
    ///
    /// For more information on Grants/ACLs refer:
    /// <see href="http://docs.amazonwebservices.com/AmazonS3/latest/index.html?RESTAuthentication.html"/>
    /// </summary>
    public class S3Grant
    {
        private S3Grantee grantee;
        private S3Permission permission;

        /// <summary>
        /// Creates a string representation of a Grant.
        /// </summary>
        /// <returns>The string representation of the Grant.</returns>
        public override string ToString()
        {
            return String.Concat("S3Grantee: ", grantee, " S3Permission: ", this.Permission);
        }

        /// <summary>
        /// Gets and sets the Grantee property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Grantee")]
        public S3Grantee Grantee
        {
            get { return this.grantee; }
            set { this.grantee = value; }
        }

        /// <summary>
        /// Sets the S3Grantee property.
        /// </summary>
        /// <param name="grantee">S3Grantee property</param>
        /// <returns>this instance</returns>
        public S3Grant WithGrantee(S3Grantee grantee)
        {
            this.grantee = grantee;
            return this;
        }

        /// <summary>
        /// Gets and sets the Permission property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Permission")]
        public S3Permission Permission
        {
            get { return this.permission; }
            set { this.permission = value; }
        }

        /// <summary>
        /// Sets the S3Permission property.
        /// </summary>
        /// <param name="permission">S3Permission property</param>
        /// <returns>this instance</returns>
        public S3Grant WithPermission(S3Permission permission)
        {
            this.permission = permission;
            return this;
        }

        internal string ToXML()
        {
            StringBuilder sb = new StringBuilder(1024);
            sb.Append("<Grant>");
            if (Grantee.CanonicalUser != null && !string.IsNullOrEmpty(Grantee.CanonicalUser.First))
            {
                sb.Append("<Grantee xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:type=\"CanonicalUser\">");
                sb.Append("<ID>").Append(this.Grantee.CanonicalUser.First).Append("</ID>");
                sb.Append("<DisplayName>").Append(this.Grantee.CanonicalUser.Second).Append("</DisplayName>");
                sb.Append("</Grantee>");
                sb.Append("<Permission>").Append(this.Permission).Append("</Permission>");
            }
            else if (this.Grantee.IsSetEmailAddress())
            {
                sb.Append("<Grantee xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:type=\"AmazonCustomerByEmail\">");
                sb.Append("<EmailAddress>").Append(this.Grantee.EmailAddress).Append("</EmailAddress>");
                sb.Append("</Grantee>");
                sb.Append("<Permission>").Append(this.Permission).Append("</Permission>");
            }
            else if (this.Grantee.IsSetURI())
            {
                sb.Append("<Grantee xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:type=\"Group\">");
                sb.Append("<URI>").Append(this.Grantee.URI).Append("</URI>");
                sb.Append("</Grantee>");
                sb.Append("<Permission>").Append(this.Permission).Append("</Permission>");
            }
            sb.Append("</Grant>");

            return sb.ToString();
        }
    }
}

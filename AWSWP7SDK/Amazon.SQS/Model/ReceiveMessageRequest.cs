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
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Amazon.SQS.Model
{
    /// <summary>
    /// Retrieves one or more messages from the specified queue, including the message body and message ID of each message.
    /// Message returned by this action stay in the queue until you delete them. However, once a message is returned to a
    /// ReceiveMessage request, it is not returned on subsequent ReceiveMessage requests for the duration of the
    /// VisibilityTimeout. If you do not specify a VisibilityTimeout in the request, the overall visibility timeout for the
    /// queue is used for the returned messages.
    /// </summary>
    [XmlRootAttribute(Namespace = "http://queue.amazonaws.com/doc/2009-02-01/", IsNullable = false)]
    public class ReceiveMessageRequest
    {
        private string queueUrl;
        private decimal? maxNumberOfMessages;
        private decimal? visibilityTimeout;
        private List<string> attributeNames;

        /// <summary>
        /// Gets and sets the QueueUrl property.
        /// The URL associated with the Amazon SQS queue.
        /// </summary>
        [XmlElementAttribute(ElementName = "QueueUrl")]
        public string QueueUrl
        {
            get { return this.queueUrl; }
            set { this.queueUrl = value; }
        }

        /// <summary>
        /// Sets the QueueUrl property
        /// </summary>
        /// <param name="queueUrl">The URL associated with the Amazon SQS queue.</param>
        /// <returns>this instance</returns>
        public ReceiveMessageRequest WithQueueUrl(string queueUrl)
        {
            this.queueUrl = queueUrl;
            return this;
        }

        /// <summary>
        /// Checks if QueueUrl property is set
        /// </summary>
        /// <returns>true if QueueUrl property is set</returns>
        public bool IsSetQueueUrl()
        {
            return this.queueUrl != null;
        }

        /// <summary>
        /// Gets and sets the MaxNumberOfMessages property.
        /// Maximum number of messages to return. SQS never returns more messages than this value but might return fewer.
        /// Not necessarily all the messages in the queue are returned (for more information, see the preceding note about
        /// machine sampling). Values can be from 1 to 10. Default is 1.
        /// </summary>
        [XmlElementAttribute(ElementName = "MaxNumberOfMessages")]
        public decimal MaxNumberOfMessages
        {
            get { return this.maxNumberOfMessages.GetValueOrDefault(); }
            set { this.maxNumberOfMessages = value; }
        }

        /// <summary>
        /// Sets the MaxNumberOfMessages property
        /// </summary>
        /// <param name="maxNumberOfMessages">Maximum number of messages to return. SQS never returns more messages than this value but might return fewer.
        /// Not necessarily all the messages in the queue are returned (for more information, see the preceding note about
        /// machine sampling). Values can be from 1 to 10. Default is 1.</param>
        /// <returns>this instance</returns>
        public ReceiveMessageRequest WithMaxNumberOfMessages(Byte maxNumberOfMessages)
        {
            this.maxNumberOfMessages = maxNumberOfMessages;
            return this;
        }

        /// <summary>
        /// Checks if MaxNumberOfMessages property is set
        /// </summary>
        /// <returns>true if MaxNumberOfMessages property is set</returns>
        public bool IsSetMaxNumberOfMessages()
        {
            return this.maxNumberOfMessages.HasValue;
        }

        /// <summary>
        /// Gets and sets the VisibilityTimeout property.
        /// The duration (in seconds) that the received messages are hidden from subsequent retrieve requests after being retrieved
        /// by a ReceiveMessage request. The value can be 0 to 43200 (maximum 12 hours).
        /// </summary>
        [XmlElementAttribute(ElementName = "VisibilityTimeout")]
        public decimal VisibilityTimeout
        {
            get { return this.visibilityTimeout.GetValueOrDefault(); }
            set { this.visibilityTimeout = value; }
        }

        /// <summary>
        /// Sets the VisibilityTimeout property
        /// </summary>
        /// <param name="visibilityTimeout">The duration (in seconds) that the received messages are hidden from subsequent retrieve requests after being retrieved
        /// by a ReceiveMessage request. The value can be 0 to 43200 (maximum 12 hours).</param>
        /// <returns>this instance</returns>
        public ReceiveMessageRequest WithVisibilityTimeout(UInt16 visibilityTimeout)
        {
            this.visibilityTimeout = visibilityTimeout;
            return this;
        }

        /// <summary>
        /// Checks if VisibilityTimeout property is set
        /// </summary>
        /// <returns>true if VisibilityTimeout property is set</returns>
        public bool IsSetVisibilityTimeout()
        {
            return this.visibilityTimeout.HasValue;
        }

        /// <summary>
        /// Gets the AttributeName property.
        /// The attribute you want to get. Valid values: All | SenderId | SentTimestamp | ApproximateReceiveCount |
        /// ApproximateFirstReceiveTimestamp
        /// </summary>
        [XmlElementAttribute(ElementName = "AttributeName")]
        public List<string> AttributeName
        {
            get
            {
                if (this.attributeNames == null)
                {
                    this.attributeNames = new List<string>();
                }
                return this.attributeNames;
            }
        }

        /// <summary>
        /// Sets the AttributeName property
        /// </summary>
        /// <param name="list">The attribute you want to get. Valid values: All | SenderId | SentTimestamp | ApproximateReceiveCount |
        /// ApproximateFirstReceiveTimestamp</param>
        /// <returns>this instance</returns>
        public ReceiveMessageRequest WithAttributeName(params string[] list)
        {
            foreach (string item in list)
            {
                AttributeName.Add(item);
            }
            return this;
        }

        /// <summary>
        /// Checks if AttributeName property is set
        /// </summary>
        /// <returns>true if AttributeName property is set</returns>
        public bool IsSetAttributeName()
        {
            return (AttributeName.Count > 0);
        }

    }
}

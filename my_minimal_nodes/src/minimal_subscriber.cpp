#include <ros/ros.h>
#include <std_msgs/Float64.h>

void myCallback(const std_msgs::Float64& message_holder){
	//it wakes up every time topic is published
	ROS_INFO("received value is: %f",message_holder.data);//ROS_INFO is like a printf()
}

int main(int argc, char **argv)
{
	ros::init(argc,argv,"minimal_subscriber");//name of the node

	ros::NodeHandle n;//to establish communication

	ros::Subscriber my_subscriber_object = n.subscribe("topic1",1,myCallback);

	ros::spin();// this is essentially a while statement forces refreshing wakeups upon new data arrival

return 0;//should never get here unless roscore dies


}

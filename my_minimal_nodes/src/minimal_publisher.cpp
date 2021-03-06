#include <ros/ros.h>
#include <std_msgs/Float64.h>

int main(int argc, char **argv){
	ros::init(argc, argv, "minimal_publisher"); // name of this node will be "minimal_publisher
	ros::NodeHandle n; // two lines to create a publisher object that can talk to ROS
	ros::Publisher my_publisher_object = n.advertise<std_msgs::Float64>("topic1", 1);// "topic1" is the name which will publish, the "1" argument says to use a buffer size of 1, could make larger, if expect network backups

	std_msgs::Float64 input_float;// create a variable of type "Float 64"

	input_float.data = 0.0;

	//infinite loop, but terminate if detect ROS has faulted

	while (ros::ok()){
		//this loop has no sleep timer		
		input_float.data = input_float.data + 0.001;//inc by 0.001 each iteration
		my_publisher_object.publish(input_float); //publish the value of Float64
	}

}

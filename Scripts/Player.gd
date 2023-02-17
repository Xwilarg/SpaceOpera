extends KinematicBody2D

var speed = 200
var reload_time = 0.0

func _ready():
	pass

func _physics_process(delta):
	if reload_time > 0.0:
		reload_time -= delta

	var x = 0
	var y = 0

	if Input.is_action_pressed("move_right"):
		x = 1
	elif Input.is_action_pressed("move_left"):
		x = -1
	if Input.is_action_pressed("move_up"):
		y = -1
	elif Input.is_action_pressed("move_down"):
		y = 1

	var velocity = (global_transform.y * y + global_transform.x * x).normalized()
	move_and_slide(velocity * speed)
	
	if Input.is_action_pressed("shoot") && reload_time <= 0.0:
		print($RayCast2D.get_collider())
		reload_time = 1.0

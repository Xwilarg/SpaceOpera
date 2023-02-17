extends KinematicBody2D

class_name Character

var baseHealth = 100
var health: int

var shoot: Vector2
var shootTimer = -1.0

func _ready():
	health = baseHealth

func _physics_process(delta):
	if shootTimer > 0.0:
		shootTimer -= delta
		update()

func take_damage(amount):
	health -= amount
	print("Took damage, health left: " + str(health))
	if health <= 0:
		pass

func shoot(impact: Vector2):
	shoot = impact
	shootTimer = 0.5
	pass

func _draw():
	if shootTimer >= 0.0:
		# Ca marche pas et ca me gonffle
		draw_line((global_transform.y + global_transform.x), shoot , Color(0, 0, 255), 2)

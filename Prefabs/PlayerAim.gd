extends RayCast2D

func get_collision():
	look_at(get_global_mouse_position())
	if is_colliding():
		return true
	return false

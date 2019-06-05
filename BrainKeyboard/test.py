import cv2
import numpy as np
import dlib
import time
from math import hypot
print(cv2.__file__)
board = np.zeros((500, 500), np.uint8)
board[:] = 255


# Keyboard settings
keyboard = np.zeros((600, 1000, 3), np.uint8)
keys_set_1 = {0: "Q", 1: "W", 2: "E", 3: "R", 4: "T",
              5: "U", 6: "S", 7: "D", 8: "F", 9: "G",
              10: "Z", 11: "A", 12: "C", 13: "V", 14: "B"}

def letter(letter_index, text, letter_light):
    # Keys
    if letter_index == 0:
        x = 0
        y = 0
    elif letter_index == 1:
        x = 200
        y = 0
    elif letter_index == 2:
        x = 400
        y = 0
    elif letter_index == 3:
        x = 600
        y = 0
    elif letter_index == 4:
        x = 800
        y = 0
    elif letter_index == 5:
        x = 0
        y = 200
    elif letter_index == 6:
        x = 200
        y = 200
    elif letter_index == 7:
        x = 400
        y = 200
    elif letter_index == 8:
        x = 600
        y = 200
    elif letter_index == 9:
        x = 800
        y = 200
    elif letter_index == 10:
        x = 0
        y = 400
    elif letter_index == 11:
        x = 200
        y = 400
    elif letter_index == 12:
        x = 400
        y = 400
    elif letter_index == 13:
        x = 600
        y = 400
    elif letter_index == 14:
        x = 800
        y = 400

    width = 200
    height = 200
    th = 3 # thickness
    if letter_light is True:
        cv2.rectangle(keyboard, (x + th, y + th), (x + width - th, y + height - th), (255, 255, 255), -1)
    else:
        cv2.rectangle(keyboard, (x + th, y + th), (x + width - th, y + height - th), (255, 0, 0), th)

    # Text settings
    font_letter = cv2.FONT_HERSHEY_PLAIN
    font_scale = 10
    font_th = 4
    text_size = cv2.getTextSize(text, font_letter, font_scale, font_th)[0]
    width_text, height_text = text_size[0], text_size[1]
    text_x = int((width - width_text) / 2) + x
    text_y = int((height + height_text) / 2) + y
    cv2.putText(keyboard, text, (text_x, text_y), font_letter, font_scale, (255, 0, 0), font_th)



font = cv2.FONT_HERSHEY_PLAIN





# Counters
frames = 0
letter_index = 0
blinking_frames = 0
text = ""

while True:
    keyboard[:] = (0, 0, 0)
    frames += 1
    new_frame = np.zeros((500, 500, 3), np.uint8)

    active_letter = keys_set_1[letter_index]




    # Letters
    if frames == 15:
        letter_index += 1
        frames = 0
    if letter_index == 15:
        letter_index = 0


    for i in range(15):
        if i == letter_index:
            light = True
        else:
            light = False
        letter(i, keys_set_1[i], light)
    if cv2.waitKey(33) == ord(' ') :
        text += active_letter


    cv2.putText(board, text, (10, 100), font, 4, 0, 3)


    #cv2.imshow("Frame", frame)
    #cv2.imshow("New frame", new_frame)
    cv2.imshow("Brain Keyboard for GTU", keyboard)
    cv2.imshow("Board", board)

    key = cv2.waitKey(1)
    if key == 27:
        break
    time.sleep(0.25)

cv2.destroyAllWindows()

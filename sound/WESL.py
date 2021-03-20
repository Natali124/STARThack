# Work Environment Sound Loop

# first install the library: pip install python-vlc
import vlc
import time

print('*********************************************')
print('Welcome to WESL (Work Environment Sound Loop)')
print('---------------------------------------------')
print("You can choose between 'groove', 'rainbow',")
print("or 'elevator'.")
print("Then you can set the time for how long you")
print('want to work and then you are already done.')
print('*********************************************')
print('')

while True:
    print('What kind of music would you like to listen')
    music_sel = input('to? ')
    if music_sel == 'groove':
        music = vlc.MediaPlayer('sounds/groove.mp3')
        break
    elif music_sel == 'rainbow':
        music = vlc.MediaPlayer('sounds/rainbow.mp3')
        break
    elif music_sel == 'elevator':
        music = vlc.MediaPlayer('sounds/elevator.mp3')
        break
    else:
        print("Please select one of the options listed above.")
        print('')

print('')
print('Great choice! Now, for how long will you')
print('work?')

while True:
    hr = input('Hours: ')
    try:
        hr = int(hr)
        break
    except ValueError:
        print('ERROR: Not an integer')
        continue

while True:
    mi = input('Minutes: ')
    try:
        mi = int(mi)
        break
    except ValueError:
        print('ERROR: Not an integer')
        continue

time_work = int(mi)*60 + int(hr)*3600
time_end = time.time()+time_work

while time.time() < time_end:
    music.play()
    time.sleep(180)
    music.stop()

#music.stop()

#music.play()

#time.sleep(time_work)

print('')
print('********************************************')
print('You completed your chunk of work.')
print('Congrats!')
print('********************************************')
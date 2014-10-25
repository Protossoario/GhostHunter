using UnityEngine;
using System.Collections;

public static class VibrationModule {
	static bool[] playing = new bool[] {
		false,
		false,
		false,
		false
	};
	static long[][] patterns = new long[][] {
		new long[] {0, 50, 600},
		new long[] {0, 50, 150, 50, 400},
		new long[] {0, 100, 200, 100, 200},
		new long[] {0, 100, 100, 100, 100}
	};

	public static void playPattern(int pattern) {
		if (playing[pattern]) {
			return;
		}
		stop();
		Debug.Log("Playing pattern " + pattern);
		Vibration.Vibrate(patterns[pattern], 0);
		playing[pattern] = true;
	}

	public static bool isPlayingSomething() {
		for (int i = 0; i < playing.Length; i++) {
			if (playing[i]) {
				return true;
			}
		}
		return false;
	}

	private static void turnAllOff() {
		for (int i = 0; i < playing.Length; i++) {
			playing[i] = false;
		}
	}

	public static void stop() {
		if (isPlayingSomething()) {
			Debug.Log("Stopping all patterns");
			Vibration.Cancel();
			turnAllOff();
		}
	}
}

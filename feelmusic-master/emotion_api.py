import urllib2
import json
from watson_developer_cloud import NaturalLanguageUnderstandingV1
from watson_developer_cloud.natural_language_understanding_v1 import Features, EmotionOptions
import flask
from flask import request, jsonify


def analyze_comments_with_watson(comments):
	natural_language_understanding = NaturalLanguageUnderstandingV1(
		version='2018-11-16',
		iam_apikey='IPkgGqeeR21yec6gCIZu05TQNb59Kn3lnGB2aSri9lhs',
		url='https://gateway.watsonplatform.net/natural-language-understanding/api'
	)
	response = natural_language_understanding.analyze(text=comments,features=Features(emotion=EmotionOptions())).get_result()
	return response


def get_comments(json_contents):
	all_comments = ""
	for i in range(0, len(json_contents['items'])):
		comment = json_contents['items'][i]['snippet']['topLevelComment']['snippet']['textDisplay']
		all_comments += comment + '\n'
	return all_comments


app = flask.Flask(__name__)

@app.route('/emotion', methods=['GET'])
def analyze_video():
	videoId = 'dQw4w9WgXcQ'
	if request.args.get('videoId'):
		videoId = request.args.get('videoId')
	all_comments = ""
	contents = urllib2.urlopen('https://www.googleapis.com/youtube/v3/commentThreads?part=snippet&videoId={id}&key=AIzaSyDetY8piqKshTANt3-QeXTX4YtNbAM_TsE&maxResults=100'.format(id=videoId)).read()
	for i in range(0, 5):
		contents = json.loads(contents)
		all_comments += get_comments(contents)
		next_page_token = contents['nextPageToken']
		contents = urllib2.urlopen('https://www.googleapis.com/youtube/v3/commentThreads?part=snippet&videoId={id}&key=AIzaSyDetY8piqKshTANt3-QeXTX4YtNbAM_TsE&maxResults=100&pageToken={nextPageToken}'.format(id = videoId, nextPageToken = next_page_token)).read()
	video_analysis = analyze_comments_with_watson(all_comments)
	return flask.jsonify(video_analysis)


@app.route('/')
def index():
	return analyze_video()


@app.route('/populate')
def populate_database():
	contents = urllib2.urlopen('https://www.googleapis.com/youtube/v3/playlistItems?part=snippet%2CcontentDetails&maxResults=50&playlistId=PL1QoyRI3p8dUSymDZAAhT_Lb7KU8A7ANB&key=AIzaSyDetY8piqKshTANt3-QeXTX4YtNbAM_TsE').read()
	contents = json.loads(contents)
	return flask.jsonify(contents)
	


if __name__ == '__main__':
	app.run('localhost', 8090, debug=True)

Feature: WordpressAddCommentFeature
As User I Want To Leave A Comment For First Post
@comments
Scenario: As User I Want To Leave A Comment For First Post
	Given I enter to home page
	When I leave comment for first post:
	| Author     | Content    | Email      |
	| RandomText | RandomText | RandomMail |
	Then I see "Your comment is awaiting moderation."

Scenario: As User I Should See Validation When I Want To Put Wrong Mail
	Given I enter to home page
	When I leave comment for first post:
	| Author     | Content    | Email |
	| RandomText | randomText |fake  |
	Then I see information about invalid mail "Invalid email address"

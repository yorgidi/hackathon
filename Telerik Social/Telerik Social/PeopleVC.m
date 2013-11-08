//
//  PeopleVC.m
//  Telerik Social
//
//  Created by Stanimir Karoserov on 07.11.13.
//  Copyright (c) 2013 г. Telerik. All rights reserved.
//

#import <MessageUI/MessageUI.h>
#import <MessageUI/MFMailComposeViewController.h>
#import "PeopleData.h"
#import "PersonCell.h"
#import "Utils.h"
#import "PeopleVC.h"

@interface PeopleVC () <UISearchBarDelegate, PersonCellDelegate, MFMailComposeViewControllerDelegate>

@property (nonatomic, strong) IBOutlet UISearchBar* searchBar;

@end

@implementation PeopleVC {
    PeopleData* _peopleData;
    NSArray* _currentData;
}

- (id)initWithStyle:(UITableViewStyle)style
{
    self = [super initWithStyle:style];
    if (self) {
        // Custom initialization
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
    
    //[self.tableView registerClass:PersonCell.class forCellReuseIdentifier:@"Cell"];

    _peopleData = [[PeopleData alloc] init];
    _currentData = [_peopleData peopleForFilter:@""];
    // Uncomment the following line to preserve selection between presentations.
    // self.clearsSelectionOnViewWillAppear = NO;
 
    // Uncomment the following line to display an Edit button in the navigation bar for this view controller.
    // self.navigationItem.rightBarButtonItem = self.editButtonItem;
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

#pragma mark - Table view data source

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView
{
    // Return the number of sections.
    return 1;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    // Return the number of rows in the section.
    return _currentData.count;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    static NSString *CellIdentifier = @"Cell";
    PersonCell *cell = [tableView dequeueReusableCellWithIdentifier:CellIdentifier forIndexPath:indexPath];
    
    // Configure the cell...

    NSDictionary* data = _currentData[indexPath.row];
    cell.personName.text = data[@"name"];
    cell.personTeam.text = data[@"team"];
    
    NSString* name = [((NSString *)data[@"name"]) lowercaseString];
    cell.personImage.image = [UIImage imageNamed:[name stringByAppendingString:@".jpg"]];
    
    cell.index = indexPath.row;
    cell.delegate = self;
    
    return cell;
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    NSDictionary* data = _currentData[indexPath.row];
    NSString *phoneNumber = [@"tel://" stringByAppendingString:data[@"phone"]];
    [[UIApplication sharedApplication] openURL:[NSURL URLWithString:phoneNumber]];
#if TARGET_IPHONE_SIMULATOR
    [Utils showAlertWithTitle:@"Simulator"
                  andMessage:[NSString stringWithFormat:@"Cannot call %@ on Simulator", data[@"phone"]]];
#endif
}

- (void)searchBar:(UISearchBar *)searchBar textDidChange:(NSString *)searchText
{
    _currentData = [_peopleData peopleForFilter:searchText];
    [self.tableView reloadData];
}

-(void)onEmail:(PersonCell *)cell
{
    NSDictionary* data = _currentData[cell.index];
    NSString* email = data[@"email"];
    [self showMailComposer:email];
}

#pragma mark - Mail sending code and delegates

// Displays an email composition interface inside the application. Populates all the Mail fields.
- (void)showMailComposer:(NSString *)email
{
	Class mailClass = (NSClassFromString(@"MFMailComposeViewController"));
	if (mailClass != nil) {
		// Test to ensure that device is configured for sending emails.
		if ([mailClass canSendMail]) {
			MFMailComposeViewController *picker = [[MFMailComposeViewController alloc] init];
			picker.mailComposeDelegate = self;
			[picker setSubject:NSLocalizedString(@"Telerik Social", @"used for email subject")];
			// Fill out the email body text
			NSString *emailBody = @"";
			[picker setMessageBody:emailBody isHTML:NO];
			[picker setToRecipients:@[email]];
			
			[self presentViewController:picker animated:YES completion:nil];
		}
		else {
			// Device is not configured for sending emails, so notify user.
            [Utils showAlertWithTitle:NSLocalizedString(@"Unable to e-mail", @"title for cannot email") andMessage:NSLocalizedString(@"This device is not yet configured for sending e-mails.", @"message for not being able to send e-mail")];
		}
	}
}

// Dismisses the Mail composer when the user taps Cancel or Send.
- (void)mailComposeController:(MFMailComposeViewController*)controller
		  didFinishWithResult:(MFMailComposeResult)result error:(NSError*)error
{
	NSString *resultTitle = nil;
	NSString *resultMsg = nil;
	switch (result)
	{
		case MFMailComposeResultCancelled:
			resultTitle = NSLocalizedString(@"E-mail Cancelled", @"message title for canceled e-mail");
			resultMsg = NSLocalizedString(@"You elected to cancel the e-mail", @"message for canceled e-mail");
			break;
		case MFMailComposeResultSaved:
			resultTitle = NSLocalizedString(@"E-mail Saved", @"message title for draft e-mail");
			resultMsg = NSLocalizedString(@"You saved the e-mail as a draft", @"message for draft e-mail");
			break;
		case MFMailComposeResultSent:
			resultTitle = NSLocalizedString(@"E-mail Sent", @"message title for sent e-mail");
			resultMsg = NSLocalizedString(@"Your e-mail was successfully delivered", @"message for sent email");
			break;
		case MFMailComposeResultFailed:
			resultTitle = NSLocalizedString(@"E-mail Failed", @"message title for failed email");
			resultMsg = NSLocalizedString(@"Sorry, the Mail Composer failed. Please try again.", @"message for failed e-mail");
			break;
		default:
			resultTitle = NSLocalizedString(@"E-mail Not Sent", @"message title for not sent e-mail");
			resultMsg = NSLocalizedString(@"Sorry, an error occurred. Your e-mail could not be sent.", @"message for not sent e-mail");
			break;
	}
	// Notifies user of any Mail Composer errors received with an Alert View dialog.
    //[Utils showAlertWithTitle:resultTitle andMessage:resultMsg];
	[self dismissViewControllerAnimated:YES completion:nil];
}

/*
#pragma mark - Navigation

// In a story board-based application, you will often want to do a little preparation before navigation
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender
{
    // Get the new view controller using [segue destinationViewController].
    // Pass the selected object to the new view controller.
}

 */

@end

//
//  Utils.m
//  Telerik Connect
//
//  Created by Stanimir Karoserov on 08.11.13.
//  Copyright (c) 2013 г. Telerik. All rights reserved.
//

#import "Utils.h"

@implementation Utils

+ (void)showAlertWithTitle:(NSString *)title andMessage:(NSString *)message
{
    UIAlertView* alert = [[UIAlertView alloc] initWithTitle:title message:message delegate:nil cancelButtonTitle:@"OK" otherButtonTitles:nil];
    [alert show];
}

@end

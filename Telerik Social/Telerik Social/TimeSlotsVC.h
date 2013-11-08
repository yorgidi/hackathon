//
//  TimeSlotsVC.h
//  Telerik Connect
//
//  Created by Stanimir Karoserov on 08.11.13.
//  Copyright (c) 2013 г. Telerik. All rights reserved.
//

#import <UIKit/UIKit.h>

@protocol TimeSlotDelegate <NSObject>

- (void)onTimeSlotSelected:(NSString *)text;

@end

@interface TimeSlotsVC : UIViewController

@property (nonatomic, weak) id<TimeSlotDelegate> delegate;

@end

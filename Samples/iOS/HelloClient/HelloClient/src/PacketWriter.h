//
//  Generated by the J2ObjC translator.  DO NOT EDIT!
//  source: ./com/us/openserver/protocols/PacketWriter.java
//

#ifndef _ComUsOpenserverProtocolsPacketWriter_H_
#define _ComUsOpenserverProtocolsPacketWriter_H_

#include "J2ObjC_header.h"
#include "java/lang/Runnable.h"

@class ComUsOpenserverSessionSession;
@class IOSByteArray;
@class JavaLangException;

@interface ComUsOpenserverProtocolsPacketWriter : NSObject < JavaLangRunnable >

#pragma mark Public

- (instancetype)initWithComUsOpenserverSessionSession:(ComUsOpenserverSessionSession *)session
                                        withByteArray:(IOSByteArray *)packet;

- (void)execute;

- (JavaLangException *)getException;

- (void)run;

@end

J2OBJC_EMPTY_STATIC_INIT(ComUsOpenserverProtocolsPacketWriter)

FOUNDATION_EXPORT void ComUsOpenserverProtocolsPacketWriter_initWithComUsOpenserverSessionSession_withByteArray_(ComUsOpenserverProtocolsPacketWriter *self, ComUsOpenserverSessionSession *session, IOSByteArray *packet);

FOUNDATION_EXPORT ComUsOpenserverProtocolsPacketWriter *new_ComUsOpenserverProtocolsPacketWriter_initWithComUsOpenserverSessionSession_withByteArray_(ComUsOpenserverSessionSession *session, IOSByteArray *packet) NS_RETURNS_RETAINED;

J2OBJC_TYPE_LITERAL_HEADER(ComUsOpenserverProtocolsPacketWriter)

#endif // _ComUsOpenserverProtocolsPacketWriter_H_